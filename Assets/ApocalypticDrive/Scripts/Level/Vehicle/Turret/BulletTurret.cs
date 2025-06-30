using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class BulletTurret : MonoBehaviour, ITurret
    {
        [field: SerializeField] public float ShootingFrequency { get; private set; }

        [SerializeField] private Bullet projectilePrefab;
        [SerializeField] private Transform projectileMount;
        
        public GameObject Root => gameObject;
        public Transform Transform => transform;

        private Transform bulletContainer;

        private void Start()
        {
            bulletContainer = new GameObject("Bullet Container").transform;
        }

        public void Shoot()
        {
            Bullet projectile = Instantiate(projectilePrefab);
            projectile.transform.rotation = transform.rotation;
            projectile.transform.position = projectileMount.position;
            projectile.transform.SetParent(bulletContainer);
            projectile.Launch();
        }
    }
}
