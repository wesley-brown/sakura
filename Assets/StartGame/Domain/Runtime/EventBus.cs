using UnityEngine;

namespace Sakura.StartGame.Domain
{
    /// <summary>
    /// Provides communication between decoupled components.
    /// </summary>
    public sealed class EventBus : MonoBehaviour
    {
        [SerializeField] private Simulation simulation = null;

        /// <summary>
        /// Register a given entity.
        /// </summary>
        /// <param name="entity">The entity to register.</param>
        /// <returns>True</returns>
        public bool Register(Entity entity)
        {
            return true;
        }
    }
}
