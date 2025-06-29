using Zenject;
using MeShineFactory.ApocalypticDrive.Level.State;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;
using MeShineFactory.ApocalypticDrive.Level;
using UnityEngine;
using MeShineFactory.ApocalypticDrive.Level.Config;

namespace MeShineFactory.ApocalypticDrive
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private LevelConfig levelConfig;
        [SerializeField] private DefaultCameraController cameraController;

        public override void InstallBindings()
        {
            Container.Bind<IUserInputController>().To<UserInputController>().AsSingle();
            Container.Bind<IStateFactory<LevelStateData>>().To<LevelStateFactory>().AsSingle();
            Container.Bind<LevelConfig>().FromInstance(levelConfig).AsSingle();
            Container.Bind<ILevelEnvironment>().To<ClassicLevelEnvironment>().AsSingle();
            Container.Bind<ICameraController>().FromInstance(cameraController);
            Container.Bind<LevelProgressListener>().AsSingle();
            Container.Bind<LevelStateMachine>().AsSingle();

            ProjectLog.Info("[Installer] bindings installed");
        }
    }
}
