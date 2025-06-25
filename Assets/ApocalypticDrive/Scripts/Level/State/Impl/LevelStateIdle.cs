using System;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateIdle : IState<LevelStateData>
    {
        public event Action<LevelStateData> OnStateChangeRequest;

        public async UniTask Start(IStateData stateData)
        {
#warning TODO: level state Action
            ProjectLog.Info("[LevelState] idle start");
            await UniTask.CompletedTask;
        }

        public async UniTask Stop()
        {
#warning TODO: level state Stop
            ProjectLog.Info("[LevelState] idle stop");
            await UniTask.CompletedTask;
        }
    }
}
