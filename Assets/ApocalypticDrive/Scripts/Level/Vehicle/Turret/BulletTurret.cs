using UnityEngine;
using Zenject;
using MeShineFactory.ApocalypticDrive.Audio;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class BulletTurret : MonoBehaviour, ITurret
    {
        [Inject] private IAudioManager audioManager;

        [field: SerializeField] public float ShootingFrequency { get; private set; }

        [SerializeField] private Bullet projectilePrefab;
        [SerializeField] private Transform projectileMount;
        [SerializeField] private AudioSource audioSource;
        
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

            audioManager.PlaySound(SoundID.Shot, audioSource);
        }
    }
}
