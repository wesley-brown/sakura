using UnityEngine;
using UnityEngine.Events;

namespace Sakura.Interactions
{
    /// <summary>
    /// A reaction.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class Reaction : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onInteract = null;

        [SerializeField] private GameObject nextStage = null;

        public void React()
        {
            Instantiate(nextStage, transform);
            Destroy(gameObject);
            //onInteract.Invoke();
        }
    }

    
}
