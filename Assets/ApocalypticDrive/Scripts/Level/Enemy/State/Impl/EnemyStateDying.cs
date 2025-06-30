using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;
using MeShineFactory.ApocalypticDrive.Audio;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyStateDying : BaseEnemyState
    {
        [Inject] private IAudioManager audioManager;

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

            if (components.IsMuted is false)
                audioManager.PlaySound(SoundID.BodyBurst, components.AudioSource);
        }

        private void OnDeathAnimationCompleted()
        {
            components.AnimatorListener.OnAnimationCompleted -= OnDeathAnimationCompleted;
            GameObject.Destroy(components.Root);
        }
    }
}
