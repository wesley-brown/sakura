using UnityEngine;

namespace Sakura.Entities
{
    /// <summary>
    /// An entity.
    /// </summary>
    public sealed class Entity : MonoBehaviour
    {
        /// <summary>
        /// The game object that this entity represents.
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return gameObject;
            }
        }

        /// <summary>
        /// Destroy this entity's game object after the current frame.
        /// </summary>
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
