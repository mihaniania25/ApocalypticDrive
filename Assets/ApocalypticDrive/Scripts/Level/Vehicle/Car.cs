using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class Car : MonoBehaviour, IVehicle
    {
        [field: SerializeField] public float Speed { get; private set; }

        public Vector3 Position => transform.position;
    }
}
