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

        private EnemyEventBus eventBus = new();
        private EnemyStateMachine stateMachine;

        private async void Start()
        {
            components.Health.Value = components.MaxHealth;

            eventBus.Subscribe(EnemyEventType.Dying, EnemyDyingHandler);
            stateMachine = diContainer.Instantiate<EnemyStateMachine>(new object[] { components, eventBus });
            await stateMachine.RunState(EnemyStateType.Idle);
        }

        private void EnemyDyingHandler(BusEventData<EnemyEventType> eventData)
        {
            OnDead?.Invoke(this);
        }

        public void Die()
        {
            stateMachine.RunState(EnemyStateType.Dead).Forget();
        }

        public void DieInstantly()
        {
            components.Health.SetValueSilently(0f);
            stateMachine.Dispose().Forget();
            Destroy(gameObject);
        }
    }
}
