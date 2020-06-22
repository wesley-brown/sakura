using UnityEngine;

namespace Sakura.Interactions
{
    /// <summary>
    /// A raycast.
    /// </summary>
    public sealed class Raycast
    {
        private readonly Ray ray;
        private readonly Collider collider;

        public static Raycast WithRayAndCollider(
            Ray ray,
            Collider collider)
        {
            return new Raycast(ray, collider);
        }

        private Raycast(Ray ray, Collider collider)
        {
            this.ray = ray;
            this.collider = collider;
        }

        /// <summary>
        /// Whether or not this Raycast's ray hit its collider.
        /// </summary>
        public bool Hit
        {
            get
            {
                RaycastHit hit;
                return collider.Raycast(ray, out hit, float.PositiveInfinity);
            }
        }
    }
}
