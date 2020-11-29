using System;
using UnityEngine;

namespace Sakura.StartGame.Domain
{
    /// <summary>
    /// Provides communication between decoupled components.
    /// </summary>
    public sealed class EventBus : MonoBehaviour
    {
        [Header("Parameters")]
        public Simulation forSimulation = null;

        private Simulation simulation = null;

        private void Start()
        {
            if (!forSimulation)
            {
                throw new InvalidOperationException(
                    "forSimulation must not be null");
            }
            else
            {
                simulation = forSimulation;
                forSimulation = null;
            }
        }

        /// <summary>
        /// Register a given entity.
        /// </summary>
        /// <param name="entity">The entity to register.</param>
        public void Register(Entity entity)
        {
            simulation.Include(entity);
        }
    }
}
