using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public interface IVehicle
    {
        Vector3 Position { get; }
        float Speed { get; }

        UniTask StartMoving();
        UniTask Park();
        UniTask Explode();
    }
}
