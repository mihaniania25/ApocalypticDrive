using UnityEngine;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level;

namespace MeShineFactory.ApocalypticDrive
{
    public class Cleaner : MonoBehaviour
    {
        [Inject] private ILevelEnvironment levelEnvironment;
        [Inject] private ICameraController cameraController;

        private void OnApplicationQuit()
        {
            levelEnvironment.StopBuilding();
            cameraController.StopFollowingVehicle();
        }
    }
}