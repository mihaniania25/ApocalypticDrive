using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public interface ICameraController
    {
        UniTask LookAtVehicleSide();
        UniTask LookAtVehicleBack();
        void StartFollowingVehicle();
        void StopFollowingVehicle();
    }
}
