using UnityEngine;

namespace Sakura.Interactions
{
    /// <summary>
    /// A reaction that deletes its attached game object when interacted with.
    /// </summary>
    public sealed class AttachedGameObjectDeleter : MonoBehaviour, Reaction
    {
        public void React()
        {
            Destroy(gameObject);
        }
    }
}
