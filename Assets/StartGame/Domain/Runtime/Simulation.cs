using UnityEngine;
using System.Collections.Generic;

namespace Sakura.StartGame.Domain
{
    /// <summary>
    /// An approximate imitation of the world of Sakura.
    /// </summary>
    [CreateAssetMenu(fileName = "New Simulation", menuName = "Simulation")]
    public sealed class Simulation : ScriptableObject
    {
        private List<Entity> entities = null;

        private void Awake()
        {
            entities = new List<Entity>();
        }

        /// <summary>
        /// The entities in this simulation.
        /// </summary>
        public IEnumerable<Entity> Entities
        {
            get
            {
                return new List<Entity>(entities);
            }
        }

        /// <summary>
        /// Include a given entity in this simulation.
        /// </summary>
        /// <param name="entity">The entity to include.</param>
        public void Include(Entity entity)
        {
            entities.Add(entity);
        }
    }
}
