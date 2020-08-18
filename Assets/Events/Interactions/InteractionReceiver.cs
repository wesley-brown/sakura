using UnityEngine.EventSystems;

namespace Sakura.Events.Interactions
{
    public interface InteractionReceiver : IEventSystemHandler
    {
        void Receive(Interaction interaction);
    }
}
