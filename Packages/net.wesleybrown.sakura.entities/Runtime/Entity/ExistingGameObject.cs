using UnityEngine;
using System;

namespace Sakura.Entities.Entity
{
    /// <summary>
    /// A game object that is not null.
    /// </summary>
    internal sealed class ExistingGameObject
    {
        private readonly GameObject gameObject;

        internal static ExistingGameObject ForGameObject(GameObject gameObject)
        {
            if (gameObject == null)
            {
                throw new ArgumentNullException("gameObject");
            }
            else
            {
                return new ExistingGameObject(gameObject);
            }
        }

        private ExistingGameObject(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public GameObject GameObject
        {
            get
            {
                return gameObject;
            }
        }

        public ExistingTransform Transform
        {
            get
            {
                return ExistingTransform.ForTransform(gameObject.transform);
            }
        }

        public ExistingGameObject Parent
        {
            get
            {
                var parentTransform = Transform.Parent;
                return ForGameObject(parentTransform.GameObject);
            }
        }
    }
}