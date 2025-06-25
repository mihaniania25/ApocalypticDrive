using System;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public abstract class LevelState : IState<LevelStateData>
    {
        public event Action<LevelStateData> OnStateChangeRequest;

        public abstract UniTask Start(IStateData stateData);

        public virtual async UniTask Stop()
        {
            await UniTask.CompletedTask;
        }
    }
}
