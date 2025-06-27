using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateMachine : StateMachine<LevelStateData>
    {
        public async UniTask RunState(LevelStateType levelStateType)
        {
            LevelStateData stateData = new(levelStateType);
            await RunState(stateData);
        }
    }
}
