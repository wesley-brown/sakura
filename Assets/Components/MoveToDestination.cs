using UnityEngine;

namespace Sakura.Components
{
    public sealed class MoveToDestination : Component
    {
        private readonly Entity entity;
        private readonly Vector3 destination;
        private readonly Vector3 startingLocation;
        private readonly Vector3 heading;

        public MoveToDestination(Entity entity, Vector3 destination)
        {
            this.entity = entity;
            this.destination = destination;
            startingLocation = entity.Location;
            heading = destination - startingLocation;
        }

        public void Update()
        {
            var direction = Vector3.Normalize(destination - entity.Location);
            entity.TranslateIn(direction);
            var traveled = entity.Location - startingLocation;
            if (traveled.magnitude > heading.magnitude)
            {
                // Gone past destination
                entity.TeleportTo(destination);
                entity.Remove(this);
            }
        }
    }
}
