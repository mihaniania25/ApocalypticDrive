using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public interface IUserInputController
    {
        bool IsScreenUnderTouch { get; }
        UniTask WaitScreenTouch();
        float GetHorizontalViewportInput();
    }
}
