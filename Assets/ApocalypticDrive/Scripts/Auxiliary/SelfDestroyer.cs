using UnityEngine;

namespace MeShineFactory.ApocalypticDrive
{
    public class SelfDestroyer : MonoBehaviour
    {
        [SerializeField] private float destroyDelay = 3f;

        private float destroyTime;

        private void Awake()
        {
            destroyTime = Time.time + destroyDelay;
        }

        private void Update()
        {
            if (Time.time >= destroyTime)
                Destroy(gameObject);
        }
    }
}
