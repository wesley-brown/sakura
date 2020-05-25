using UnityEngine;
using System;

namespace Sakura.Entities.Entity.Methods
{
    /// <summary>
    /// Causes an entity to destroy itself.
    /// </summary>
    [RequireComponent(typeof(Entity))]
    public sealed class Destroy : MonoBehaviour
    {
        private Entity entity = null;

        private void Awake()
        {
            entity = GetComponent<Entity>();
        }

        private void OnEnable()
        {
            Destroy(entity.GameObject);
            enabled = false;
        }
    }
}
