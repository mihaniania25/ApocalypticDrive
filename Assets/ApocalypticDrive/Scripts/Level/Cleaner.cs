using UnityEngine;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level;
using MeShineFactory.ApocalypticDrive.Level.Model;

namespace MeShineFactory.ApocalypticDrive
{
    public class Cleaner : MonoBehaviour
    {
        [Inject] private ILevelEnvironment levelEnvironment;
        [Inject] private ICameraController cameraController;
        [Inject] private GameSessionModel sessionModel; 

        private void OnApplicationQuit()
        {
            levelEnvironment.StopBuilding();
            cameraController.StopFollowingVehicle();
            sessionModel.Enemies.ForEach(e => e.DieInstantly());
        }
    }
}