using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public interface IVehicle
    {
        Vector3 Position { get; }
        float Speed { get; }
    }
}
