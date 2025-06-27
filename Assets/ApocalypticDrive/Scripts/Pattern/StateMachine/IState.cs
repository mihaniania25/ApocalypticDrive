using System;
using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Pattern.StateMachine
{
    public interface IState<DataType> where DataType : IStateData
    {
        event Action<DataType> OnStateChangeRequest;

        UniTask Start(IStateData stateData);
        UniTask Stop();
    }
}
