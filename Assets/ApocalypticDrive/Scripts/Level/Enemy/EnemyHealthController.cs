using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.LocalEventBus;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyHealthController
    {
        [Inject] private IVehicle vehicle;

        private EnemyComponents components;

        public EnemyHealthController(EnemyComponents components)
        {
            this.components = components;
        }

        public void Setup()
        {
            components.Health.Subscribe(OnEnemyHealthChange);
            components.EventBus.Subscribe(EnemyEventType.HitVehicle, OnEnemyHitVehicle);
            components.HealthBar.gameObject.SetActive(false);
        }

        private void OnEnemyHitVehicle(BusEventData<EnemyEventType> eventData)
        {
            vehicle.TakeDamage(components.Damage);
            components.Health.Value = 0f;
        }

        public void TakeDamage(float damage)
        {
            float newHealth = Mathf.Clamp(components.Health.Value - damage, 0f, components.MaxHealth);
            components.Health.Value = newHealth;

            if (newHealth > 0f)
                components.FxController.PlayInjuryFx();
        }

        private void OnEnemyHealthChange(float health)
        {
            components.HealthBar.gameObject.SetActive(health > 0f && health < components.MaxHealth);
            components.HealthBar.Progress.Value = health / components.MaxHealth;

            if (health <= 0f)
                components.StateMachine.RunState(EnemyStateType.Dead).Forget();
        }

        public void Dispose()
        {
            components.EventBus.Unsubscribe(EnemyEventType.HitVehicle, OnEnemyHitVehicle);
        }
    }
}
