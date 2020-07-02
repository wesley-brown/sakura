using UnityEngine;
using System;

namespace Sakura.Entities
{
    /// <summary>
    /// A game object that references another game object which may or may not
    /// be itself.
    /// </summary>
    public sealed class Entity : MonoBehaviour
    {
        [SerializeField]
        private GameObject forGameObject = null;

        [SerializeField]
        private GameObject forParentOf = null;

        private ExistingGameObject referencedGameObject = null;

        private void Awake()
        {
            if (BothPropertiesAreUnassigned || OnlyOnePropertyIsAssigned)
            {
                InitializeUsingThatOneProperty();
            }
            else
            {
                throw new InvalidOperationException(
                    "Only one or neither of "
                    + "'For Game Object' "
                    + "or "
                    + "'For Parent Of' "
                    + " on "
                    + gameObject.name
                    + "'s Entity component may be assigned.");
            }
        }

        /// <summary>
        /// Destroy this entity's game object after the current frame.
        /// </summary>
        public void Destroy()
        {
            Destroy(gameObject);
        }

        public GameObject GameObject
        {
            get
            {
                return referencedGameObject.GameObject;
            }
        }

        private bool OnlyOnePropertyIsAssigned
        {
            get
            {
                return forGameObject ^ forParentOf;
            }
        }

        /// <summary>
        /// Whether or not both of the forGameObject and forParentOf properties 
        /// have been unassigned.
        /// </summary>
        /// <remarks>
        /// This property is temporary and used only to ensure backwards
        /// compatibility with entities that existed before the adition of the
        /// Destroy method.
        /// </remarks>
        private bool BothPropertiesAreUnassigned
        {
            get
            {
                return !(forGameObject && forParentOf);
            }
        }

        private void InitializeUsingThatOneProperty()
        {
            if (forGameObject != null)
            {
                referencedGameObject =
                    ExistingGameObject
                    .ForGameObject(forGameObject);
            }
            else if (forParentOf != null)
            {
                referencedGameObject =
                    ExistingGameObject
                    .ForGameObject(forParentOf)
                    .Parent;
            }
        }
    }
}
