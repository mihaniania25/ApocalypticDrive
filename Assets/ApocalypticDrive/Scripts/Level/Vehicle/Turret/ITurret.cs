using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public interface ITurret
    {
        GameObject Root { get; }
        Transform Transform { get; }

        float ShootingFrequency { get; }

        void Shoot();
    }
}
