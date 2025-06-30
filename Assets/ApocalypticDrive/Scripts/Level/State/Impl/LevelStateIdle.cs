using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;
using MeShineFactory.ApocalypticDrive.Level.Model;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateIdle : BaseLevelState
    {
        [Inject] private IUserInputController userInputController;
        [Inject] private ICameraController cameraController;
        [Inject] private LazyInject<IVehicle> vehicle;
        [Inject] private GameSessionModel sessionModel;

        public override async UniTask Start(IStateData stateData)
        {
            ProjectLog.Info("[LevelStateIdle] Start");

            sessionModel.Health.Value = vehicle.Value.MaxHealth;

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
