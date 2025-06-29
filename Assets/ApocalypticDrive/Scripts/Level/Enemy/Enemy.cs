using System;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<IEnemy> OnDead;

        [SerializeField] private Animator animator;
        [SerializeField] private AnimatorListener animatorListener;
        [SerializeField] private string animDeadStateName;

        [SerializeField] private Collider mainCollider;
        [SerializeField] private Rigidbody mainRigidbody;

        public void Die()
        {
            OnDead?.Invoke(this);

            Destroy(mainCollider);
            Destroy(mainRigidbody);

            animatorListener.OnAnimationCompleted += OnDeathAnimationCompleted;
            animator.SetBool(animDeadStateName, true);
        }

        private void OnDeathAnimationCompleted()
        {
            animatorListener.OnAnimationCompleted -= OnDeathAnimationCompleted;
            Destroy(gameObject);
        }
    }
}
