using System;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Level.Config;
using MeShineFactory.ApocalypticDrive.Level.Model;
using UnityEditor.TestTools.CodeCoverage;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelProgressListener
    {
        public event Action OnLevelDistancePassed;
        public event Action OnVehicleHealthLost;

        [Inject] private IVehicle vehicle;
        [Inject] private LevelConfig levelConfig;
        [Inject] private GameSessionModel sessionModel;

        private bool isListeningEnabled = false;

        public void Start()
        {
            isListeningEnabled = true;
            sessionModel.Health.Subscribe(OnHealthChanged);
            ListenToDistanceProgress().Forget();
        }

        private async UniTask ListenToDistanceProgress()
        {
            float duration = levelConfig.LevelDistance / vehicle.Speed;
            float targetTime = Time.time + duration;

            while (isListeningEnabled)
            {
                if (Time.time >= targetTime)
                {
                    OnLevelDistancePassed?.Invoke();
                    break;
                }

                await UniTask.Yield();
            }
        }

        private void OnHealthChanged(float health)
        {
            if (health <= 0f)
                OnVehicleHealthLost?.Invoke();
        }

        public void Stop()
        {
            isListeningEnabled = false;
            sessionModel.Health.Unsubscribe(OnHealthChanged);
        }
    }
}
