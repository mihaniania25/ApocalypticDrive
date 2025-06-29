using Cysharp.Threading.Tasks;
using Zenject;
using MeShineFactory.ApocalypticDrive.Pattern.LocalEventBus;

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
        }

        private void OnEnemyHitVehicle(BusEventData<EnemyEventType> eventData)
        {
            vehicle.TakeDamage(components.Damage);
            components.Health.Value = 0f;
        }

        private void OnEnemyHealthChange(float health)
        {
            if (health <= 0f)
                components.StateMachine.RunState(EnemyStateType.Dead).Forget();
#warning TODO: blood splash on hit
        }

        public void Dispose()
        {
            components.EventBus.Unsubscribe(EnemyEventType.HitVehicle, OnEnemyHitVehicle);
        }
    }
}
