namespace MeShineFactory.ApocalypticDrive.Pattern.StateMachine
{
    public interface IStateFactory<DataType> where DataType : IStateData
    {
        IState<DataType> GetState(DataType dataType);
    }
}
