using System;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Level.Config;

namespace MeShineFactory.ApocalypticDrive.Level.State
{
    public class LevelProgressListener
    {
        public event Action OnLevelDistancePassed;
        public event Action OnVehicleHealthLost;

        [Inject] private IVehicle vehicle;
        [Inject] private LevelConfig levelConfig;

        private bool isListeningEnabled = false;

        public void Start()
        {
            isListeningEnabled = true;
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

        public void Stop()
        {
            isListeningEnabled = false;
        }
    }
}
