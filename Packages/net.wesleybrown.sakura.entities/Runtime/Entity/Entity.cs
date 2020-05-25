using UnityEngine;
using System;

namespace Sakura.Entities
{
    /// <summary>
    /// A reference to a game object in a scene.
    /// </summary>
    public sealed class Entity : MonoBehaviour
    {
        [SerializeField]
        private GameObject forGameObject = null;

        private GameObject referencedGameObject = null;

        private void Awake()
        {
            if (forGameObject == null)
            {
                throw new InvalidOperationException(
                    "'For Game Object' property of "
                    + gameObject.name
                    + "'s Entity component "
                    + "must not be null.");
            }
            else
            {
                referencedGameObject = forGameObject;
            }
        }

        public GameObject GameObject
        {
            get
            {
                return referencedGameObject;
            }
        }
    }
}
