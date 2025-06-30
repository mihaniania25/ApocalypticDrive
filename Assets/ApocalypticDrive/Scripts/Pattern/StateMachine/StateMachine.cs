using Zenject;
using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Pattern.StateMachine
{
    public abstract class StateMachine<DataType> : IStateMachine<DataType> where DataType : IStateData
    {
        [Inject] public IStateFactory<DataType> stateFactory;

        private IState<DataType> currentState;

        public virtual async UniTask Setup()
        {
            await UniTask.CompletedTask;
        }

        public async UniTask RunState(DataType stateData)
        {
            await StopCurrentState();

            currentState = stateFactory.GetState(stateData);
            InjectStateData(stateData);

            currentState.OnStateChangeRequest += HandleStateChangeRequest;

            await currentState.Start(stateData);
        }

        protected virtual void InjectStateData(DataType stateData)
        {

        }

        private async UniTask StopCurrentState()
        {
            if (currentState != null)
            {
                currentState.OnStateChangeRequest -= HandleStateChangeRequest;
;
                await currentState.Stop();

                currentState = null;
            }
        }

        private void HandleStateChangeRequest(DataType stateData)
        {
            RunState(stateData).Forget();
        }

        public virtual async UniTask Dispose()
        {
            await StopCurrentState();
            await UniTask.CompletedTask;
        }
    }
}
