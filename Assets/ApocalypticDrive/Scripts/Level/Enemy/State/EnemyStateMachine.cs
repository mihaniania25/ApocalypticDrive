using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyStateMachine : StateMachine<EnemyStateData>
    {
        private EnemyComponents enemyComponents;
        private EnemyEventBus eventBus;

        public EnemyStateMachine(EnemyComponents enemyComponents, EnemyEventBus eventBus)
        {
            this.enemyComponents = enemyComponents;
            this.eventBus = eventBus;
        }

        public async UniTask RunState(EnemyStateType stateType)
        {
            EnemyStateData stateData = new(stateType);
            await RunState(stateData);
        }

        protected override void InjectStateData(EnemyStateData stateData)
        {
            stateData.EnemyComponents = enemyComponents;
            stateData.EventBus = eventBus;
        }
    }
}
