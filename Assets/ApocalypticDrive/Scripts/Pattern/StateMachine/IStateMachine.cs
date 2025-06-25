using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Pattern.StateMachine
{
    public interface IStateMachine<DataType> where DataType : IStateData
    {
        UniTask Setup();
        UniTask RunState(DataType stateData);
        UniTask Dispose();
    }
}
