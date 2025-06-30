using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyStateData : IStateData
    {
        public EnemyStateType StateType { get; private set; }
        public EnemyComponents EnemyComponents { get; set; }
        public EnemyEventBus EventBus { get; set; }

        public EnemyStateData(EnemyStateType stateType)
        {
            StateType = stateType;
        }
    }
}
