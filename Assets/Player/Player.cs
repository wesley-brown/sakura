using Sakura.Input;
using Sakura.Movement;
using Sakura.Parameters.Primitives;
using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// A player.
    /// </summary>
    [RequireComponent(typeof(CameraParameter))]
    [RequireComponent(typeof(FloatParameter))]
    [RequireComponent(typeof(CharacterControllerParameter))]
    public sealed class Player : MonoBehaviour
    { 
        private TouchInputDetector touchInputDetector = null;

        private void Awake()
        {
            touchInputDetector = GetComponentInChildren<TouchInputDetector>();
        }

        /// <summary>
        /// Freeze this player, stopping all movement.
        /// </summary>
        public void Freeze()
        {
            touchInputDetector.enabled = false;
        }

        /// <summary>
        /// Unfreeze this player, allowing movement.
        /// </summary>
        public void Unfreeze()
        {
            touchInputDetector.enabled = true;
        }
    }
}
