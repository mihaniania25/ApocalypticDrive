using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace MeShineFactory.ApocalypticDrive.UI
{
    public class LevelUIManager : MonoBehaviour, ILevelUIManager
    {
        [SerializeField] private List<LevelScreen> screens;
        [SerializeField] private float fadeDuration = 0.4f;

        private CancellationTokenSource cancellationTokenSource = new();

        private TweenerCore<float, float, FloatOptions> fadeTweener;
        private LevelScreen currentScreen;

        public void ShowScreen(LevelScreenType screenType)
        {
            HideScreen();

            currentScreen = screens.Find(s => s.ScreenType == screenType);
            ShowScreenRoutine(cancellationTokenSource.Token).Forget();
        }

        private async UniTask ShowScreenRoutine(CancellationToken ct)
        {
            bool fadeCompleted = false;

            currentScreen.Alpha = 0f;
            currentScreen.gameObject.SetActive(true);

            fadeTweener = DOTween.To(() => currentScreen.Alpha, x => currentScreen.Alpha = x, 1f, fadeDuration)
                .SetEase(Ease.InOutExpo);
            fadeTweener.onComplete = () => fadeCompleted = true;

            await UniTask.WaitUntil(() => fadeCompleted || ct.IsCancellationRequested);
        }

        public void HideScreen()
        {
            KillFade();

            if (currentScreen != null)
            {
                currentScreen.Alpha = 0f;
                currentScreen.gameObject.SetActive(false);

                currentScreen = null;
            }
        }

        private void KillFade()
        {
            fadeTweener?.Kill();

            cancellationTokenSource.Cancel();
            cancellationTokenSource = new();
        }
    }
}
