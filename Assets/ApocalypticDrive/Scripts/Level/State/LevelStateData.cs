using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateData : IStateData
    {
        public LevelStateType StateType { get; private set; }

        public LevelStateData(LevelStateType stateType)
        {
            StateType = stateType;
        }
    }
}
