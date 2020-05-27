using UnityEngine;
using System;

namespace Sakura.Entities.Methods
{
    /// <summary>
    /// Causes a prefab to instantiate itself at the same location of the given
    /// entity.
    /// </summary>
    [RequireComponent(typeof(Prefab))]
    public sealed class InstantiateAtLocationOfEntity : MonoBehaviour
    {
        [SerializeField]
        private GameObject ofEntity = null;

        private Entity entity = null;
        private Prefab prefab = null;
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
                    + ".InstantiateAtLocationOfEntity"
                    + " must not be null.");
            }
            else
            {
                entity = ofEntity.GetComponent<Entity>();
                prefab = GetComponent<Prefab>();
            }
        }

        public GameObject InstantiatedGameObject
        {
            get
            {
                return instantiatedGameObject;
            }
        }

        public Vector3 Location
        {
            get
            {
                return instantiatedGameObject.transform.position;
            }
        }

        private void OnEnable()
        {
            instantiatedGameObject = Instantiate(
                prefab.Asset,
                entity.GameObject.transform.position,
                Quaternion.identity);
            enabled = false;
        }
    }
}
