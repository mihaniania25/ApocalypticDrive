using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyHitDetector : MonoBehaviour
    {
        private EnemyComponents components;

        public void Setup(EnemyComponents components)
        {
            this.components = components;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == Tags.Player)
                components.EventBus.Broadcast(EnemyEventType.HitVehicle);
        }
    }
}
