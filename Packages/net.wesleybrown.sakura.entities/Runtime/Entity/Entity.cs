using UnityEngine;

namespace Sakura.Entities
{
    /// <summary>
    /// An entity.
    /// </summary>
    [RequireComponent(typeof(GameObjectParameter))]
    public sealed class Entity : MonoBehaviour
    {
        private GameObjectParameter gameObjectParameter = null;

        private void Awake()
        {
            gameObjectParameter = GetComponent<GameObjectParameter>();
        }

        /// <summary>
        /// The game object that this entity represents.
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return gameObjectParameter.Value;
            }
        }

        /// <summary>
        /// Destroy this entity's game object after the current frame.
        /// </summary>
        public void Destroy()
        {
            Destroy(GameObject);
        }
    }
}
