using UnityEngine;

namespace Sakura.Entities.Methods
{
    [RequireComponent(typeof(Prefab))]
    public sealed class InstantiateAsChildOfAtLocationOf : MonoBehaviour
    {
        [SerializeField]
        private Entity asChildOf = null;

        [SerializeField]
        private Entity atLocationOf = null;

        private Prefab prefab = null;
        private Transform parentTransform = null;
        private Vector3 location = Vector3.zero;
        private GameObject instantiatedGameObject = null;

        private void Awake()
        {
            prefab = GetComponent<Prefab>();
        }

        public Vector3 Location
        {
            get
            {
                return location;
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
            parentTransform = asChildOf.GameObject.transform.parent;
            location = atLocationOf.GameObject.transform.position;
            instantiatedGameObject = Instantiate(
                prefab.Asset,
                location,
                Quaternion.identity,
                parentTransform);
            enabled = false;
        }
    }
}
