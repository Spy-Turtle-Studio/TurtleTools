using System;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace EventSystem
{
    public class MonoEventListener<T> : MonoBehaviour
    {
        [SerializeField] private EventBus<T> eventBus;

        [SerializeField] private string[] tags;

        protected UnityAction<T> callbacks;

        public bool CheckForTag(string t) => tags.Contains(t);

        public void Invoke(T message) => callbacks.Invoke(message);

        private void Awake() => eventBus.Subscribe(this);
    }
}