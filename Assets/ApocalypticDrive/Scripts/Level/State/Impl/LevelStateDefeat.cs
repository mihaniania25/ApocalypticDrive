using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateDefeat : BaseLevelState
    {
        [Inject] private IVehicle vehicle;

        public override async UniTask Start(IStateData stateData)
        {
            await vehicle.Park();
            await vehicle.Explode();
        }

        public override async UniTask Stop()
        {
            await UniTask.CompletedTask;
        }
    }
}
