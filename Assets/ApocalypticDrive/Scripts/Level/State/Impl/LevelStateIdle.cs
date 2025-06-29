using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateIdle : BaseLevelState
    {
        [Inject] private IUserInputController userInputController;
        [Inject] private ICameraController cameraController;

        public override async UniTask Start(IStateData stateData)
        {
            await cameraController.LookAtVehicleSide();
            await userInputController.WaitScreenTouch();
            TrySwitchState(LevelStateType.Action);
        }

        public override async UniTask Stop()
        {
            await UniTask.CompletedTask;
        }
    }
}
