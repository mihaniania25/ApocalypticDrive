using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateIdle : BaseLevelState
    {
        [Inject] private IUserInputController userInputController;

        public override async UniTask Start(IStateData stateData)
        {
            await userInputController.WaitScreenTouch();
            TrySwitchState(LevelStateType.Action);
        }

        public override async UniTask Stop()
        {
            await UniTask.CompletedTask;
        }
    }
}
