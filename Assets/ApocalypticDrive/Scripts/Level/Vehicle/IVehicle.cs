using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public interface IVehicle
    {
        Transform Transform { get; }
        Vector3 Position { get; }
        float Speed { get; }

        void TakeDamage(float damage);

        UniTask StartMoving();
        UniTask Park();
        UniTask Explode();
    }
}
