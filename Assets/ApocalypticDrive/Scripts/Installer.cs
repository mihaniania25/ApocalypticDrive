using Zenject;
using MeShineFactory.ApocalypticDrive.Level.State;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStateFactory<LevelStateData>>().To<LevelStateFactory>().AsSingle();
            Container.Bind<LevelStateMachine>().AsSingle();

            ProjectLog.Info("[Installer] bindings installed");
        }
    }
}
