using System;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive
{
    [Serializable]
    public class PropagationField<T>
    {
        [SerializeField] protected T value;

        private event Action<T> handlers;

        public T Value
        {
            get => GetValue();
            set
            {
                SetValue(value);
                handlers?.Invoke(GetValue());
            }
        }

        protected virtual T GetValue()
        {
            return value;
        }

        protected virtual void SetValue(T value)
        {
            this.value = value;
        }

        public void Subscribe(Action<T> handler, bool propagateImmediately = true)
        {
            handlers += handler;

            if (propagateImmediately)
                handler?.Invoke(Value);
        }

        public void Unsubscribe(Action<T> handler)
        {
            handlers -= handler;
        }

        public void ForcePropagate()
        {
            handlers?.Invoke(Value);
        }

        public void SetValueSilently(T value)
        {
            SetValue(value);
        }
    }
}