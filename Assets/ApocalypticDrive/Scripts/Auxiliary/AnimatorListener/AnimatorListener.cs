using System;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive
{
    public class AnimatorListener : MonoBehaviour
    {
        public event Action OnAnimationCompleted;

        public void TriggerAnimationCompleted()
        {
            OnAnimationCompleted?.Invoke();
        }
    }
}
