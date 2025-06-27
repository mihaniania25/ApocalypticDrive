using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateAction : BaseLevelState
    {
        override public async UniTask Start(IStateData stateData)
        {
#warning TODO: level state Action
            ProjectLog.Info("[LevelState] action start");
            await UniTask.CompletedTask;
        }

        override public async UniTask Stop()
        {
#warning TODO: level state Stop
            ProjectLog.Info("[LevelState] action stop");
            await UniTask.CompletedTask;
        }
    }
}
