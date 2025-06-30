using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class BulletTrace : MonoBehaviour
    {
        [SerializeField] private float cooldownDuration = 4f;

        private GameObject target;
        private bool isAlive = true;

        public void SetTarget(GameObject target)
        {
            this.target = target;
            FollowingRoutine().Forget();
        }

        public void RemoveTarget()
        {
            target = null;
        }

        private async UniTask FollowingRoutine()
        {
            while (isAlive && target is not null)
            {
                transform.position = target.transform.position;
                await UniTask.Yield();
            }

            if (isAlive)
            {
                await UniTask.WaitForSeconds(cooldownDuration);
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            isAlive = false;
        }
    }
}
