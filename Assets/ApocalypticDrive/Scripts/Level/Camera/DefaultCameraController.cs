using System;
using UnityEngine;
using DG.Tweening;
using Zenject;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Level.Config;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class DefaultCameraController : MonoBehaviour, ICameraController
    {
        [SerializeField] private Camera controllerCamera;

        [Inject] private LevelConfig levelConfig;
        [Inject] private LazyInject<IVehicle> vehicle;

        private CameraSettings cameraSettings => levelConfig.CameraSettings;

        public async UniTask LookAtVehicleSide()
        {
            await LookAtVehicle(cameraSettings.VehicleSideLook);
        }

        public async UniTask LookAtVehicleBack()
        {
            await LookAtVehicle(cameraSettings.VehicleBackLook);
        }

        private async UniTask LookAtVehicle(CameraLookData lookData)
        {
            bool isLookProcessCompleted = false;

            Vector3 targetPosition = vehicle.Value.Position + lookData.PositionOffset;
            var moveTweener = controllerCamera.transform
                .DOMove(targetPosition, cameraSettings.LookTransitionDuration)
                .SetEase(Ease.InOutExpo);

            Quaternion targetRotation = Quaternion.Euler(lookData.RotationEuler);
            var rotationTweener = controllerCamera.transform
                .DORotateQuaternion(targetRotation, cameraSettings.LookTransitionDuration)
                .SetEase(Ease.InOutExpo);

            moveTweener.onComplete = () => isLookProcessCompleted = true;

            await UniTask.WaitUntil(() => isLookProcessCompleted);
        }

        public void StartFollowingVehicle()
        {
            throw new NotImplementedException();
        }

        public void StopFollowingVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
