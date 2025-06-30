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
        [Inject] private LazyInject<IVehicle> vehicle;

        private void OnApplicationQuit()
        {
            levelEnvironment.StopBuilding();
            cameraController.StopFollowingVehicle();
            vehicle.Value.StopInstantly();
            sessionModel.Enemies.ForEach(e => e.DieInstantly());
        }
    }
}