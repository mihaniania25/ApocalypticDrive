using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.UI
{
    public class LevelScreen : MonoBehaviour
    {
        [field: SerializeField] public LevelScreenType ScreenType { get; private set; }

        [SerializeField] private CanvasGroup canvasGroup;

        public float Alpha
        {
            get => canvasGroup.alpha;
            set => canvasGroup.alpha = value;
        }
    }
}
