using UnityEngine;

namespace Sakura
{
    public sealed class Entity
    {
        private Vector3 location;

        public Entity(Vector3 location)
        {
            this.location = location;
        }

        public Vector3 Location
        {
            get
            {
                return location;
            }
        }
    }
}
