using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class TurretController : ITurretController
    {
        [Inject] private LazyInject<ITurret> turret;
        [Inject] private IUserInputController inputController;

        private bool isTurretEnabled = false;
        private float minShootInterval;
        private float lastShootTime;

        public void Enable()
        {
            SetupShootingTimeData();

            isTurretEnabled = true;
            TurretRoutine().Forget();
        }

        private void SetupShootingTimeData()
        {
            minShootInterval = 1f / turret.Value.ShootingFrequency;
            lastShootTime = Time.time - minShootInterval;
        }

        private async UniTask TurretRoutine()
        {
            while (isTurretEnabled)
            {
                if (inputController.IsScreenUnderTouch)
                {
                    UpdateTurretRotation();
                    TryShoot();
                }

                await UniTask.Yield();
            }
        }

        private void UpdateTurretRotation()
        {
            float userHorizontalInput = inputController.GetHorizontalViewportInput();
            turret.Value.Transform.rotation = Quaternion.AngleAxis(90.0f * userHorizontalInput, Vector3.up);
        }

        private void TryShoot()
        {
            if (Time.time >= (lastShootTime + minShootInterval))
            {
                turret.Value.Shoot();
                lastShootTime = Time.time;
            }
        }

        public void Disable()
        {
            isTurretEnabled = false;
        }
    }
}
