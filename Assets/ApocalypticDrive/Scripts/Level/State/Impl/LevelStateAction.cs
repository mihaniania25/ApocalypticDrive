using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateAction : BaseLevelState
    {
        public override async UniTask Start(IStateData stateData)
        {
#warning TODO: level state Action
            await UniTask.CompletedTask;
        }

        public override async UniTask Stop()
        {
#warning TODO: level state Stop
            await UniTask.CompletedTask;
        }
    }
}
