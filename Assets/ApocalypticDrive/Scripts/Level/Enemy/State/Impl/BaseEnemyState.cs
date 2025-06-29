using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public abstract class BaseEnemyState : IState<EnemyStateData>
    {
        public event Action<EnemyStateData> OnStateChangeRequest;

        [Inject] protected IVehicle vehicle;

        protected EnemyStateData enemyStateData { get; private set; }

        protected EnemyEventBus eventBus => enemyStateData.EventBus;
        protected EnemyComponents components => enemyStateData.EnemyComponents;

        protected Transform transform => components.Root.transform;
        protected bool isAlive => components.Health.Value > 0;

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

        protected float GetDistanceToVehicle()
        {
            return Vector3.Distance(components.Root.transform.position, vehicle.Position);
        }
    }
}
