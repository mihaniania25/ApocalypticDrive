using System;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level.Config
{
    [Serializable]
    public class CameraLookData
    {
        [field: SerializeField] public Vector3 PositionOffset { get; private set; }
        [field: SerializeField] public Vector3 RotationEuler { get; private set; }
    }
}
