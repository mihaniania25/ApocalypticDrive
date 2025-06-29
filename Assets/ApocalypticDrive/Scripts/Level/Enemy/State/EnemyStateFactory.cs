using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyStateFactory : IStateFactory<EnemyStateData>
    {
        [Inject] private DiContainer diContainer;

        public IState<EnemyStateData> GetState(EnemyStateData stateData)
        {
            if (stateData is null || stateData.StateType is EnemyStateType.None)
            {
                ProjectLog.Error("[EnemyStateFactory] input data is null or invalid");
                return null;
            }

            IState<EnemyStateData> state = GetStateByType(stateData.StateType);
            return state;
        }

        private IState<EnemyStateData> GetStateByType(EnemyStateType type)
        {
            switch (type)
            {
                case EnemyStateType.Idle:
                    return diContainer.Instantiate<EnemyStateIdle>();
                case EnemyStateType.Chase:
                    return diContainer.Instantiate<EnemyStateChase>();
                case EnemyStateType.Dead:
                    return diContainer.Instantiate<EnemyStateDying>();
                default:
                    ProjectLog.Error($"[EnemyStateFactory] no implementation for type '{type}'");
                    return null;
            }
        }
    }
}
