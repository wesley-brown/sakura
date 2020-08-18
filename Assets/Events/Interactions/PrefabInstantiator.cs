using UnityEngine;

namespace Sakura.Events.Interactions
{
    public sealed class PrefabInstantiator :
        MonoBehaviour,
        SuccessfulInteractionReceiver
    {
        [SerializeField] private GameObject prefab = null;

        public void Receive()
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
