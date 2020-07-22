using UnityEngine;

namespace Sakura
{
    public sealed class Entity
    {
        private readonly GameObject gameObject;

        public Entity(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
