using UnityEngine;
using System;

namespace Sakura.Entities
{
    public sealed class Prefab : MonoBehaviour
    {
        [SerializeField]
        private GameObject forGameObject = null;

        private void Awake()
        {
            if (forGameObject == null)
            {
                throw new InvalidOperationException(
                    "'For Game Object' "
                    + "property of "
                    + gameObject.name
                    + "'s Prefab component "
                    + "must not be null.");
            }
        }

        public GameObject Asset
        {
            get
            {
                return forGameObject;
            }
        }
    }
}
