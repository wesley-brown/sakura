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
            if (OnlyOnePropertyIsAssigned)
            {
                InitializeUsingThatOneProperty();
            }
            else
            {
                throw new InvalidOperationException(
                    "Only one of "
                    + "'For Game Object' "
                    + "or "
                    + "'For Parent Of' "
                    + " on "
                    + gameObject.name
                    + "'s Entity component may be assigned.");
            }
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
