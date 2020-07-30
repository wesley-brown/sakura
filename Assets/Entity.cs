using System.Collections.Generic;
using UnityEngine;

namespace Sakura
{
    public sealed class Entity
    {
        private Vector3 location;
        private readonly List<Components.Component> components;
        private readonly List<Components.Component> toBeRemoved;
        private float speed;    // Per tick

        public Entity(Vector3 location, float speed)
        {
            this.location = location;
            components = new List<Components.Component>();
            toBeRemoved = new List<Components.Component>();
            this.speed = speed;
        }

        public Vector3 Location
        {
            get
            {
                return location;
            }
        }

        public void Update()
        {
            foreach (var component in toBeRemoved)
            {
                components.Remove(component);
            }
            toBeRemoved.Clear();

            foreach (var component in components)
            {
                component.Update();
            }
        }

        public void TranslateIn(Vector3 direction)
        {
            location += direction * speed;
        }

        public void TeleportTo(Vector3 location)
        {
            this.location = location;
        }

        public void Add(Components.Component component)
        {
            components.Add(component);
        }

        public void Remove(Components.Component component)
        {
            toBeRemoved.Add(component);
        }
    }
}
