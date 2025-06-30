using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class Car : MonoBehaviour, IVehicle
    {
        [field: SerializeField] public float Speed { get; private set; }

        [SerializeField] private float accelerationDuration;
        [SerializeField] private Rigidbody carRigidbody;

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

        public void TakeDamage(float damage)
        {
#warning TODO: car take damage
        }
    }
}
