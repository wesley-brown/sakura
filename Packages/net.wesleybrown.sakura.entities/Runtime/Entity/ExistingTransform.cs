using UnityEngine;
using System;

namespace Sakura.Entities.Entity
{
    /// <summary>
    /// A transform that is not null.
    /// </summary>
    internal sealed class ExistingTransform
    {
        private readonly Transform transform;

        internal static ExistingTransform ForTransform(Transform transform)
        {
            if (transform == null)
            {
                throw new ArgumentNullException("transform");
            }
            else
            {
                return new ExistingTransform(transform);
            }
        }

        private ExistingTransform(Transform transform)
        {
            this.transform = transform;
        }

        public Transform Transform
        {
            get
            {
                return transform;
            }
        }

        public ExistingTransform Parent
        {
            get
            {
                return ForTransform(transform.parent);
            }
        }

        public GameObject GameObject
        {
            get
            {
                return transform.gameObject;
            }
        }
    }
}
