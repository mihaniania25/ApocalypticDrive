using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public interface IUserInputController
    {
        UniTask WaitScreenTouch();
    }
}
