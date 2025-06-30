using System;

namespace MeShineFactory.ApocalypticDrive.Pattern.LocalEventBus
{
    public abstract class BusEventData<T> where T : Enum
    {
        public T EventType { get; private set; }

        protected BusEventData(T eventType)
        {
            EventType = eventType;
        }
    }
}
