using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;
using MeShineFactory.ApocalypticDrive.UI;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelStateDefeat : BaseLevelState
    {
        [Inject] private IVehicle vehicle;
        [Inject] private ICameraController cameraController;
        [Inject] private IUserInputController userInputController;
        [Inject] private IEnemyArmyController enemyArmyController;
        [Inject] private ILevelUIManager levelUIManager;

        public override async UniTask Start(IStateData stateData)
        {
            ProjectLog.Info("[LevelStateDefeat] Start");
            enemyArmyController.DestroyAllEnemies();

            await vehicle.Park();
            await vehicle.Explode();
            cameraController.StopFollowingVehicle();

            levelUIManager.ShowScreen(LevelScreenType.Defeat);

            await userInputController.WaitScreenTouch();
            TrySwitchState(LevelStateType.Idle);
        }

        public override async UniTask Stop()
        {
            levelUIManager.HideScreen();
            await UniTask.CompletedTask;
        }
    }
}
