using Sakura.DetectPlayerMovement.Client;
using UnityEngine;

namespace Sakura.DetectPlayerMovement.Unity
{
    /// <summary>
    ///     Configures which implementations of the infrastructure layer are
    ///     used by detect player movement components.
    /// </summary>
    public abstract class DetectPlayerMovementConfig : ScriptableObject
    {
        public abstract AllDestinationInputs Create();
    }
}
