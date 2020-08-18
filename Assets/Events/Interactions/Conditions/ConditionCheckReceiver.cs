using UnityEngine.EventSystems;

namespace Sakura.Events.Interactions.Conditions
{
    public interface ConditionCheckReceiver : IEventSystemHandler
    {
        void Receive(Condition condition);
    }
}
