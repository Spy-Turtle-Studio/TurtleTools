using UnityEngine;

namespace EventSystem.IntEvent
{
    [CreateAssetMenu(fileName = "Integer Event Bus", menuName = "EventBus/Integer", order = 0)]
    public class IntEventBus : EventBus<int> {}
}