using Zenject;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateAction : BaseLevelState
    {
        [Inject] private IVehicle vehicle;
        [Inject] private ICameraController cameraController;
        [Inject] private LevelProgressListener vehicleFlowListener;

        public override async UniTask Start(IStateData stateData)
        {
            await cameraController.LookAtVehicleBack();
            await vehicle.StartMoving();

            vehicleFlowListener.OnLevelDistancePassed += OnLevelDistancePassed;
            vehicleFlowListener.OnVehicleHealthLost += OnVehicleHealthLost;
            vehicleFlowListener.Start();
        }

        private void OnLevelDistancePassed()
        {
            TrySwitchState(LevelStateType.Victory);
        }

        private void OnVehicleHealthLost()
        {
            TrySwitchState(LevelStateType.Defeat);
        }

        public override async UniTask Stop()
        {
            StopVehicleFlowListener();
            await UniTask.CompletedTask;
        }

        private void StopVehicleFlowListener()
        {
            vehicleFlowListener.OnLevelDistancePassed -= OnLevelDistancePassed;
            vehicleFlowListener.OnVehicleHealthLost -= OnVehicleHealthLost;
            vehicleFlowListener.Stop();
        }
    }
}
