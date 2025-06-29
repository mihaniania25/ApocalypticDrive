using Zenject;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateAction : BaseLevelState
    {
        [Inject] private IVehicle vehicle;

        public override async UniTask Start(IStateData stateData)
        {
            vehicle.StartMoving();
            await UniTask.CompletedTask;
        }

        public override async UniTask Stop()
        {
#warning TODO: level state Stop
            await UniTask.CompletedTask;
        }
    }
}
