using MeShineFactory.ApocalypticDrive.Pattern.LocalEventBus;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyEventBus : EventBus<EnemyEventType>
    {
        public void Broadcast(EnemyEventType eventType)
        {
            Broadcast(new EnemyTriggerEvent(eventType));
        }
    }
}
