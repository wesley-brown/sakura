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

        /// <summary>
        /// Deactivate this entity's game object.
        /// </summary>
        public void Deactivate()
        {
            GameObject.SetActive(false);
        }

        /// <summary>
        /// Activate this entity's game object.
        /// </summary>
        public void Activate()
        {
            GameObject.SetActive(true);
        }

        /// <summary>
        /// Instantiate a new copy this entity's game object at the given
        /// location.
        /// </summary>
        /// <param name="location">Where to place the new copy.</param>
        public void InstantiateAt(Location location)
        {
            var instantiated = Instantiate(
                GameObject,
                location.Coordinates,
                Quaternion.identity);
            instantiated.SetActive(true);
        }
    }
}
