using UnityEngine;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level.State;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;
using MeShineFactory.ApocalypticDrive.Level;
using MeShineFactory.ApocalypticDrive.Level.Config;
using MeShineFactory.ApocalypticDrive.Level.Model;
using MeShineFactory.ApocalypticDrive.UI;

namespace MeShineFactory.ApocalypticDrive
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private LevelConfig levelConfig;
        [SerializeField] private DefaultCameraController cameraController;
        [SerializeField] private LevelUIManager levelUIManager;

        public override void InstallBindings()
        {
            Container.Bind<IUserInputController>().To<UserInputController>().AsSingle();
            Container.Bind<IStateFactory<LevelStateData>>().To<LevelStateFactory>().AsSingle();
            Container.Bind<IStateFactory<EnemyStateData>>().To<EnemyStateFactory>().AsSingle();
            Container.Bind<LevelConfig>().FromInstance(levelConfig).AsSingle();
            Container.Bind<ILevelEnvironment>().To<ClassicLevelEnvironment>().AsSingle();
            Container.Bind<ICameraController>().FromInstance(cameraController).AsSingle();
            Container.Bind<ILevelUIManager>().FromInstance(levelUIManager).AsSingle();
            Container.Bind<IEnemyArmyController>().To<EnemyArmyController>().AsSingle();
            Container.Bind<ITurretController>().To<TurretController>().AsSingle();
            Container.Bind<LevelProgressListener>().AsSingle();
            Container.Bind<LevelStateMachine>().AsSingle();
            Container.Bind<GameSessionModel>().AsSingle();

            ProjectLog.Info("[Installer] bindings installed");
        }
    }
}
