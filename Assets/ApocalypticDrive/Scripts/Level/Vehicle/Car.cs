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

        public Vector3 Position => transform.position;

        public void StartMoving()
        {
            MovingRoutine().Forget();
        }

        private async UniTask MovingRoutine()
        {
            await Accelerate(Vector3.forward * Speed);
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
            await Accelerate(Vector3.zero);
        }

        public async UniTask Explode()
        {
            await Accelerate(Vector3.zero);
        }
    }
}
