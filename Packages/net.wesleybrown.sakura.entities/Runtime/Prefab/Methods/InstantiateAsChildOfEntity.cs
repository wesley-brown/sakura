using UnityEngine;
using System;

namespace Sakura.Entities.Methods
{
    /// <summary>
    /// Causes a prefab to instantiate itself as a child of the given entity.
    /// </summary>
    [RequireComponent(typeof(Prefab))]
    public sealed class InstantiateAsChildOfEntity : MonoBehaviour
    {
        [SerializeField]
        private GameObject ofEntity = null;

        private Prefab prefab = null;
        private Entity entity = null;
        private GameObject instantiatedGameObject = null;

        private void Awake()
        {
            if (ofEntity == null)
            {
                throw new InvalidOperationException(
                    "Parameter "
                    + "'Of Entity' "
                    + "of "
                    + gameObject.name
                    + ".InstantiateAsChildOfEntity"
                    + " must not be null.");
            }
            else
            {
                prefab = GetComponent<Prefab>();
                entity = ofEntity.GetComponent<Entity>();
            }
        }

        public Entity Entity
        {
            get
            {
                return entity;
            }
        }

        public GameObject InstantiatedGameObject
        {
            get
            {
                return instantiatedGameObject;
            }
        }

        private void OnEnable()
        {
            instantiatedGameObject = Instantiate(
                prefab.Asset,
                entity.GameObject.transform);
            enabled = false;
        }
    }
}
