using UnityEngine;

namespace Sakura.StartGame.Domain
{
    /// <summary>
    /// A thing in a simulation.
    /// </summary>
    public sealed class Entity : MonoBehaviour
    {
        private Vector3 location = Vector3.zero;

        /// <summary>
        /// Where this entity is located.
        /// </summary>
        public Vector3 Location
        {
            get
            {
                return location;
            }
        }

        /// <summary>
        /// Move this entity along a given displacement vector.
        /// </summary>
        /// <param name="displacement">
        /// The displacement vector to move along.
        /// </param>
        public void Move(Vector3 displacement)
        {
            location += displacement;
        }
    }
}
