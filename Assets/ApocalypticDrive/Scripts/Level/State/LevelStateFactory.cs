using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateFactory : IStateFactory<LevelStateData>
    {
        readonly DiContainer diContainer;

        [Inject]
        public LevelStateFactory(DiContainer container)
        {
            diContainer = container;
        }

        public IState<LevelStateData> GetState(LevelStateData stateData)
        {
            if (stateData is null || stateData.StateType is LevelStateType.None)
            {
                ProjectLog.Error("[LevelStateFactory] input data is null or invalid");
                return null;
            }

            IState<LevelStateData> state = GetStateByType(stateData.StateType);
            return state;
        }

        private IState<LevelStateData> GetStateByType(LevelStateType type)
        {
            switch (type)
            {
                case LevelStateType.Idle:
                    return diContainer.Instantiate<LevelStateIdle>();
                case LevelStateType.Action:
                    return new LevelStateAction();
                case LevelStateType.Defeat:
                    return new LevelStateDefeat();
                case LevelStateType.Victory:
                    return new LevelStateVictory();
                default:
                    ProjectLog.Error($"[LevelStateFactory] no implementation for type '{type}'");
                    return null;
            }
        }
    }
}
