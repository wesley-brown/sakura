using Sakura.DetectPlayerMovement.Client;
using UnityEngine;

namespace Sakura.Inputs
{
    /// <summary>
    ///     A component that detects player movement each frame.
    /// </summary>
    /// <remarks>
    ///     This MonoBehaviour is a temporary implementation of the "input
    ///     component". When an actual input component is created, this
    ///     class will be removed.
    /// </remarks>
    public sealed class DetectPlayerMovement : MonoBehaviour
    {
        public DetectPlayerMovementConfig config;

        private void Start()
        {
            transform = GetComponent<Transform>();
            latestDestination = transform.position;
        }

        private new Transform transform;
        private float accumulator;

        /// <summary>
        /// The destination given by the player's input for the current tick.
        /// </summary>
        /// <returns>
        /// The destination given by the player's input for the current tick
        /// or null if no input was given.
        /// </returns>
        public Vector3? Destination()
        {
            var check = DestinationCheck.Against(config.Create());
            if (!check.PlayerMovedLastFrame())
                return null;
            var y = transform.position.y;
            var destination = check.DesiredDestination();
            return new Vector3(
                destination.x,
                y,
                destination.z);
        }

        /// <summary>
        ///     The latest destination based on player input. Only one
        ///     destination input between fixed timesteps will be accepted as
        ///     the latest destination. This will always be the first
        ///     input-based destination the player provides that occurs
        ///     between fixed timesteps.
        /// </summary>
        private Vector3 latestDestination;
        private bool canAcceptNewLatestDestination = true;

        public Vector3 CurrentDestination()
        {
            if (canAcceptNewLatestDestination)
            {
                latestDestination = transform.position;
                var check = DestinationCheck.Against(config.Create());
                if (check.PlayerMovedLastFrame())
                {
                    var y = transform.position.y;
                    var unadjustedDestination = check.DesiredDestination();
                    latestDestination = new Vector3(
                        unadjustedDestination.x,
                        y,
                        unadjustedDestination.z);
                    canAcceptNewLatestDestination = false;
                }
            }
            accumulator += Time.deltaTime;
            while (accumulator >= Time.fixedDeltaTime)
            {
                accumulator -= Time.fixedDeltaTime;
                canAcceptNewLatestDestination = true;
            }
            return latestDestination;
        }
    }
}
