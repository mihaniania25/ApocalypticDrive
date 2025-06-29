using System;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public abstract class BaseEnemyState : IState<EnemyStateData>
    {
        public event Action<EnemyStateData> OnStateChangeRequest;

        protected EnemyStateData enemyStateData { get; private set; }

        protected EnemyEventBus eventBus => enemyStateData.EventBus;
        protected EnemyComponents components => enemyStateData.EnemyComponents;

        public virtual async UniTask Start(IStateData stateData)
        {
            enemyStateData = stateData as EnemyStateData;
            await UniTask.CompletedTask;
        }

        public virtual async UniTask Stop()
        {
            await UniTask.CompletedTask;
        }

        protected void TrySwitchState(EnemyStateType stateType)
        {
            OnStateChangeRequest?.Invoke(new(stateType));
        }
    }
}
