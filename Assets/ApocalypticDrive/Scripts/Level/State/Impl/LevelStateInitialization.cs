using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level.Config;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateInitialization : BaseLevelState
    {
        [Inject] private DiContainer diContainer;
        [Inject] private LevelConfig levelConfig;
        [Inject] private ILevelEnvironment levelEnvironment;
        [Inject] private IEnemyArmyController enemyArmyController;

        public override async UniTask Start(IStateData stateData)
        {
            ProjectLog.Info("[LevelStateInitialization] Start");

            InitializeArmyController();
            InstantiateVehicle();
            InitializeEnvironment();

            TrySwitchState(LevelStateType.Idle);

            await UniTask.CompletedTask;
        }

        private void InstantiateVehicle()
        {
            GameObject vehicleGO = diContainer.InstantiatePrefab(levelConfig.VehiclePrefab);
            IVehicle vehicle = vehicleGO.GetComponent<IVehicle>();

            diContainer.Bind<IVehicle>().FromInstance(vehicle).AsSingle();
        }

        private void InitializeEnvironment()
        {
            levelEnvironment.StartBuilding();
        }

        private void InitializeArmyController()
        {
            enemyArmyController.Setup();
        }

        public override async UniTask Stop()
        {
            await UniTask.CompletedTask;
        }
    }
}
