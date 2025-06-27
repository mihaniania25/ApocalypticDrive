using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level.Config;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateInitialization : BaseLevelState
    {
        [Inject] private DiContainer diContainer;
        [Inject] private LevelConfig levelConfig;

        public override async UniTask Start(IStateData stateData)
        {
            InstantiateVehicle();
            TrySwitchState(LevelStateType.Idle);

            await UniTask.CompletedTask;
        }

        private void InstantiateVehicle()
        {
            GameObject vehicleGO = diContainer.InstantiatePrefab(levelConfig.VehiclePrefab);
            IVehicle vehicle = vehicleGO.GetComponent<IVehicle>();

            diContainer.Bind<IVehicle>().FromInstance(vehicle).AsSingle();
        }

        public override async UniTask Stop()
        {
            await UniTask.CompletedTask;
        }
    }
}
