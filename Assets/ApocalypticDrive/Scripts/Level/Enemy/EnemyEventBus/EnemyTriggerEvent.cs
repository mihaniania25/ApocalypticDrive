using MeShineFactory.ApocalypticDrive.Pattern.LocalEventBus;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyTriggerEvent : BusEventData<EnemyEventType>
    {
        public EnemyTriggerEvent(EnemyEventType eventType) : base(eventType)
        {

        }
    }
}
