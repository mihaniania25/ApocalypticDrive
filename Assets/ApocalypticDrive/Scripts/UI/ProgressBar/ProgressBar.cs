using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform barTransform;

        public PropagationField<float> Progress { get; private set; } = new();

        private void Awake()
        {
            Progress.Subscribe(OnProgressChange);
        }

        private void OnProgressChange(float progress)
        {
            Vector3 newScale = barTransform.localScale;
            newScale.x = progress;
            barTransform.localScale = newScale;
        }

        private void OnDestroy()
        {
            Progress.Unsubscribe(OnProgressChange);
        }
    }
}
