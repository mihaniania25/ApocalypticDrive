using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateVictory : BaseLevelState
    {
        [Inject] private IVehicle vehicle;
        [Inject] private ICameraController cameraController;
        [Inject] private IUserInputController userInputController;

        public override async UniTask Start(IStateData stateData)
        {
            await vehicle.Park();
            cameraController.StopFollowingVehicle();

            await userInputController.WaitScreenTouch();
            TrySwitchState(LevelStateType.Idle);
        }

        public override async UniTask Stop()
        {
            await UniTask.CompletedTask;
        }
    }
}
