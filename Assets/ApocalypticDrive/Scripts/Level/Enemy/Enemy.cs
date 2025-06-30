using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.LocalEventBus;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<IEnemy> OnDead;

        [Inject] private DiContainer diContainer;

        [SerializeField] private EnemyComponents components;
        [SerializeField] private EnemyHitDetector hitDetector;

        private EnemyHealthController healthController;

        private async void Start()
        {
            SetupHealthRelatedComponents();
            await components.StateMachine.RunState(EnemyStateType.Idle);
        }

        private void SetupHealthRelatedComponents()
        {
            components.Health.Value = components.MaxHealth;

            hitDetector.Setup(components);

            components.EventBus.Subscribe(EnemyEventType.Dying, EnemyDyingHandler);
            components.StateMachine = diContainer.Instantiate<EnemyStateMachine>(new object[] { components });

            healthController = diContainer.Instantiate<EnemyHealthController>(new object[] { components });
            components.FxController = diContainer.Instantiate<EnemyFxController>(new object[] { components });
            healthController.Setup();
        }

        private void EnemyDyingHandler(BusEventData<EnemyEventType> eventData)
        {
            OnDead?.Invoke(this);
        }

        public void TakeDamage(float damage)
        {
            healthController.TakeDamage(damage);
        }

        public void Mute()
        {
            components.IsMuted = true;
        }

        public void Die()
        {
            components.Health.Value = 0f;
        }

        public void DieInstantly()
        {
            components.Health.SetValueSilently(0f);
            components.StateMachine.Dispose().Forget();
            Destroy(gameObject);
        }
    }
}
