using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateIdle : BaseLevelState
    {
        [Inject] private IUserInputController userInputController;

        override public async UniTask Start(IStateData stateData)
        {
            ProjectLog.Info("[LevelState] IDLE start");
            await userInputController.WaitScreenTouch();
            TrySwitchState(LevelStateType.Action);
        }

        override public async UniTask Stop()
        {
            ProjectLog.Info("[LevelState] IDLE stop");
            await UniTask.CompletedTask;
        }
    }
}
