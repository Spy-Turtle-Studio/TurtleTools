using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public class EventBus<T> : ScriptableObject
    {
        private HashSet<MonoEventListener<T>> _listeners;

        public void Subscribe(MonoEventListener<T> listener) => 
            _listeners.Add(listener);

        public void Invoke(T message) =>
            _listeners
                .ToList()
                .ForEach(l => l.Invoke(message));

        public void Invoke(T message, string tag) =>
            _listeners
                .Where(l => l.CheckForTag(tag))
                .ToList()
                .ForEach(l => l.Invoke(message));

        private void Awake() => _listeners = new HashSet<MonoEventListener<T>>();
    }
}