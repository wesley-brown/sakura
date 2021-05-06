using Sakura.DetectPlayerMovement.Client;
using UnityEngine;

namespace Sakura.DetectPlayerMovement.Unity
{
    /// <summary>
    ///     A component that detects player movement each frame.
    /// </summary>
    public sealed class DetectPlayerMovement : MonoBehaviour
    {
        public DetectPlayerMovementConfig config;

        private void Update()
        {
            var check = DestinationCheck.Against(config.Create());
            if (check.PlayerMovedLastFrame())
            {
                var y = gameObject.transform.position.y;
                var destination = check.DesiredDestination();
                gameObject.transform.position = new Vector3(
                    destination.x,
                    y,
                    destination.z);
            }
        }
    }
}
