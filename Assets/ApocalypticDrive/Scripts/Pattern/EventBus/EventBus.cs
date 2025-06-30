using System;
using System.Collections.Generic;

namespace MeShineFactory.ApocalypticDrive.Pattern.LocalEventBus
{
    public abstract class EventBus<T> where T : Enum
    {
        public delegate void EventHandler(BusEventData<T> eventData);

        private Dictionary<T, List<EventHandler>> subscribers = new();

        public void Subscribe(T eventType, EventHandler handler)
        {
            if (subscribers.ContainsKey(eventType) is false)
                subscribers[eventType] = new();

            subscribers[eventType].Add(handler);
        }

        public void Unsubscribe(T eventType, EventHandler handler)
        {
            if (subscribers.ContainsKey(eventType))
                subscribers[eventType].Remove(handler);
        }

        public void Broadcast(BusEventData<T> eventData)
        {
            T eventType = eventData.EventType;

            if (subscribers.ContainsKey(eventType))
            {
                List<EventHandler> handlers = subscribers[eventType];
                handlers.ForEach(h => h?.Invoke(eventData));
            }
        }
    }
}
