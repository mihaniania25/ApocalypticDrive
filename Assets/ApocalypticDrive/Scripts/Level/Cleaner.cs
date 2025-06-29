using UnityEngine;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level;

namespace MeShineFactory.ApocalypticDrive
{
    public class Cleaner : MonoBehaviour
    {
        [Inject] private ILevelEnvironment levelEnvironment;

        private void OnApplicationQuit()
        {
            levelEnvironment.StopBuilding();
        }
    }
}