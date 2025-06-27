using Cysharp.Threading.Tasks;
using UnityEngine;
using MeShineFactory.ApocalypticDrive.Level.State;
using Zenject;

namespace MeShineFactory.ApocalypticDrive
{
    public class Launcher : MonoBehaviour
    {
        [Inject] private LevelStateMachine levelStateMachine;

        private async void Start()
        {
            ProjectLog.Info("[Launcher] start");

            await SetupLevelStateMachine();
            await levelStateMachine.RunState(LevelStateType.Idle);
            await UniTask.Delay(1000);

            await levelStateMachine.RunState(LevelStateType.Action);
            await UniTask.Delay(1000);

            await levelStateMachine.RunState(LevelStateType.Victory);
        }

        private async UniTask SetupLevelStateMachine()
        {
            await levelStateMachine.Setup();
        }    
    }
}
