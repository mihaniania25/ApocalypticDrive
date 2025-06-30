using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level.Model;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class Car : MonoBehaviour, IVehicle
    {
        [Inject] private GameSessionModel sessionModel;

        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; } = 100f;

        [SerializeField] private float accelerationDuration;
        [SerializeField] private Rigidbody carRigidbody;
        [SerializeField] private Transform turretMount;

        private bool isConstantMoving = false;

        public Transform Transform => transform;
        public Vector3 Position => transform.position;

        public async UniTask StartMoving()
        {
            await Accelerate(Vector3.forward * Speed);
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

        private async UniTask Accelerate(Vector3 targetVelocity)
        {
            bool isAccelerationCompleted = false;

            var accTween = DOTween.To(() => carRigidbody.velocity, x => carRigidbody.velocity = x,
                targetVelocity, accelerationDuration)
                .SetEase(Ease.InExpo);

            accTween.onComplete = () => isAccelerationCompleted = true;
            await UniTask.WaitUntil(() => isAccelerationCompleted);
        }

        public async UniTask Park()
        {
            isConstantMoving = false;
            await Accelerate(Vector3.zero);
        }

        public async UniTask Explode()
        {
            await UniTask.CompletedTask;
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
        }

        public void InstallTurret(ITurret turret)
        {
            turret.Transform.position = turretMount.position;
            turret.Transform.SetParent(turretMount);
        }
    }
}
