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

        public void Enable()
        {
            isTurretEnabled = true;
            TurretRoutine().Forget();
        }

        private async UniTask TurretRoutine()
        {
            while (isTurretEnabled)
            {
                if (inputController.IsScreenUnderTouch)
                {
                    UpdateTurretRotation();
                }

                await UniTask.Yield();
            }
        }

        private void UpdateTurretRotation()
        {
            float userHorizontalInput = inputController.GetHorizontalViewportInput();
            turret.Value.Transform.rotation = Quaternion.AngleAxis(90.0f * userHorizontalInput, Vector3.up);
        }

        public void Disable()
        {
            isTurretEnabled = false;
        }
    }
}
