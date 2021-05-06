using Sakura.DetectPlayerMovement.Client;
using Sakura.DetectPlayerMovement.Infrastructure;
using UnityEngine;

namespace Sakura.DetectPlayerMovement.Unity
{
    /// <summary>
    ///     A configuration for the legacy touch input plugin from the
    ///     infrastructure layer that can be used by a detect player movement
    ///     component.
    /// </summary>
    [CreateAssetMenu]
    sealed class LegacyTouchInputConfig : DetectPlayerMovementConfig
    {
        [Tooltip("The name of the layer to raycast against")]
        public string layerName;

        public override AllDestinationInputs Create()
        {
            return new LegacyTouchInput(Camera.main, layerName);
        }
    }
}
