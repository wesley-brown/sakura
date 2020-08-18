using UnityEngine.EventSystems;

namespace Sakura.Events.Interactions
{
    public interface SuccessfulInteractionReceiver : IEventSystemHandler
    {
        void Receive();
    }
}
