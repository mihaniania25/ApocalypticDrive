using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class BulletTurret : MonoBehaviour, ITurret
    {
        public GameObject Root => gameObject;
        public Transform Transform => transform;
    }
}
