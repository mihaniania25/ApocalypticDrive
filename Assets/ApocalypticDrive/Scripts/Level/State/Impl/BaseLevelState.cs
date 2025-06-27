using System;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public abstract class BaseLevelState : IState<LevelStateData>
    {
        public event Action<LevelStateData> OnStateChangeRequest;

        public abstract UniTask Start(IStateData stateData);
        public abstract UniTask Stop();

        protected void TrySwitchState(LevelStateType stateType)
        {
            OnStateChangeRequest?.Invoke(new(stateType));
        }
    }
}
