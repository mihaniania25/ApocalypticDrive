using UnityEngine;

namespace MeShineFactory.ApocalypticDrive
{
    public class CanvasCameraSetter : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        private void OnValidate()
        {
            canvas = GetComponent<Canvas>();
        }

        private void Awake()
        {
            canvas.worldCamera = Camera.main;
        }
    }
}
