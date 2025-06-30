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
            components.Health.Value = components.MaxHealth;

            hitDetector.Setup(components);

            components.EventBus.Subscribe(EnemyEventType.Dying, EnemyDyingHandler);
            components.StateMachine = diContainer.Instantiate<EnemyStateMachine>(new object[] { components });

            healthController = diContainer.Instantiate<EnemyHealthController>(new object[] { components });
            healthController.Setup();

            await components.StateMachine.RunState(EnemyStateType.Idle);
        }

        private void EnemyDyingHandler(BusEventData<EnemyEventType> eventData)
        {
            OnDead?.Invoke(this);
        }

        public void Die()
        {
            components.StateMachine.RunState(EnemyStateType.Dead).Forget();
        }

        public void DieInstantly()
        {
            components.Health.SetValueSilently(0f);
            components.StateMachine.Dispose().Forget();
            Destroy(gameObject);
        }
    }
}
