using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody bulletRigidbody;

        [Space]
        [SerializeField] private float damage;
        [SerializeField] private float speed;
        [SerializeField] private float lifetime;
        [SerializeField] private BulletTrace tracePrefab;

        private BulletTrace trace;

        private float launchTime;

        public void Launch()
        {
            InstantiateTrace();
            launchTime = Time.time;
            bulletRigidbody.velocity = transform.forward * speed;
        }

        private void InstantiateTrace()
        {
            trace = Instantiate(tracePrefab, transform.position, Quaternion.identity);
            trace.transform.SetParent(transform.parent);
            trace.SetTarget(gameObject);
        }

        private void Update()
        {
            if (Time.time > (launchTime + lifetime))
            {
                trace.RemoveTarget();
                Destroy(gameObject);
            }
        }
    }
}
