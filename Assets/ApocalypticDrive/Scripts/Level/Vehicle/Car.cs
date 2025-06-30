using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level.Model;
using MeShineFactory.ApocalypticDrive.Audio;
using MeShineFactory.ApocalypticDrive.Fx;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class Car : MonoBehaviour, IVehicle
    {
        [Inject] private GameSessionModel sessionModel;
        [Inject] private IAudioManager audioManager;

        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; } = 100f;

        [SerializeField] private float accelerationDuration;
        [SerializeField] private float lean;
        [SerializeField] private float leanDuration;
        [SerializeField] private Rigidbody carRigidbody;
        [SerializeField] private Transform turretMount;

        [SerializeField] private Animator animator;
        [SerializeField] private string hitAnimName;

        [SerializeField] private ParticleSystem explosionParticles;
        [SerializeField] private float explosionDuration = 2f;
        [SerializeField] private FlashFX flashFx;

        [SerializeField] private AudioSource movementAudioSource;
        [SerializeField] private AudioSource injuryAudioSource;

        private bool isConstantMoving = false;

        public Transform Transform => transform;
        public Vector3 Position => transform.position;

        public async UniTask StartMoving()
        {
            audioManager.PlaySound(SoundID.VehicleStart, movementAudioSource);

            LeanRoutine(0f, Ease.InExpo).Forget();
            await Accelerate(Vector3.forward * Speed, Ease.InExpo);

            ConstantMoving().Forget();
        }

        private async UniTask ConstantMoving()
        {
            isConstantMoving = true;

            while (isConstantMoving)
            {
                carRigidbody.velocity = Vector3.forward * Speed;
                await UniTask.Yield();
            }
        }

        private async UniTask LeanRoutine(float targetLean, Ease ease)
        {
            bool isLeanCompleted = false;
            float duration = Mathf.Clamp(leanDuration, 0f, accelerationDuration);

            var leanTween = transform.DORotate(Vector3.up * targetLean, duration);
            leanTween.SetEase(ease);
            leanTween.onComplete = () => isLeanCompleted = true;

            await UniTask.WaitUntil(() => isLeanCompleted);
        }

        private async UniTask Accelerate(Vector3 targetVelocity, Ease ease)
        {
            bool isAccelerationCompleted = false;

            var accTween = DOTween.To(() => carRigidbody.velocity, x => carRigidbody.velocity = x,
                targetVelocity, accelerationDuration)
                .SetEase(ease);

            accTween.onComplete = () => isAccelerationCompleted = true;
            await UniTask.WaitUntil(() => isAccelerationCompleted);
        }

        public async UniTask Park()
        {
            isConstantMoving = false;
            audioManager.PlaySound(SoundID.VehicleBreak, movementAudioSource);

            LeanRoutine(lean, Ease.OutExpo).Forget();
            await Accelerate(Vector3.zero, Ease.InExpo);
        }

        public async UniTask Explode()
        {
            explosionParticles.gameObject.SetActive(true);
            explosionParticles.Play();

            audioManager.PlaySound(SoundID.VehicleExplosion, injuryAudioSource);
            await UniTask.WaitForSeconds(explosionDuration);
        }

        public void Restore()
        {
            explosionParticles.Stop();
            explosionParticles.gameObject.SetActive(false);
        }

        public void StopInstantly()
        {
            isConstantMoving = false;
            carRigidbody.velocity = Vector3.zero;
        }

        public void TakeDamage(float damage)
        {
            float newHealth = Mathf.Clamp(sessionModel.Health.Value - damage, 0f, MaxHealth);
            sessionModel.Health.Value = newHealth;

            audioManager.PlaySound(SoundID.VehicleHit, injuryAudioSource);
            flashFx.ShowFlashFx();
            animator.SetTrigger(hitAnimName);
        }

        public void InstallTurret(ITurret turret)
        {
            turret.Transform.position = turretMount.position;
            turret.Transform.SetParent(turretMount);
        }
    }
}
