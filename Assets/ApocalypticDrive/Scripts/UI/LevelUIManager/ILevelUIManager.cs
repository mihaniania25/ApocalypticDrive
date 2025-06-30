using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.UI
{
    public interface ILevelUIManager
    {
        void ShowScreen(LevelScreenType screenType);
        void HideScreen();
    }
}
