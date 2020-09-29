using UnityEngine;

namespace Sakura.Events.Interactions
{
    public sealed class DestroyOnInteraction :
        MonoBehaviour,
        SuccessfulInteractionReceiver
    {
        public void Receive()
        {
            Destroy(gameObject);
        }
    }
}
