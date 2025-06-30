using UnityEngine;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyStateDying : BaseEnemyState
    {
        public override async UniTask Start(IStateData stateData)
        {
            await base.Start(stateData);

            components.Health.SetValueSilently(0f);
            eventBus.Broadcast(EnemyEventType.Dying);

            GameObject.Destroy(components.MainCollider);
            GameObject.Destroy(components.MainRigidbody);

            components.AnimatorListener.OnAnimationCompleted += OnDeathAnimationCompleted;
            components.Animator.SetBool(components.AnimDeadStateName, true);

            components.BloodParticles.Play();
        }

        private void OnDeathAnimationCompleted()
        {
            components.AnimatorListener.OnAnimationCompleted -= OnDeathAnimationCompleted;
            GameObject.Destroy(components.Root);
        }
    }
}
