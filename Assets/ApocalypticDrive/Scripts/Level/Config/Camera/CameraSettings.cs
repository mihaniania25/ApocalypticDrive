using System;
using UnityEngine;
using MeShineFactory.ApocalypticDrive.Level.Config;

namespace MeShineFactory.ApocalypticDrive.Level
{
    [Serializable]
    public class CameraSettings
    {
        [field: SerializeField] public CameraLookData VehicleSideLook;
        [field: SerializeField] public CameraLookData VehicleBackLook;
        [field: SerializeField] public float LookTransitionDuration;
    }
}
