using UnityEngine;
using Sakura.Entities;

namespace Sakura.Interactions
{
    public sealed class InteractablesList : MonoBehaviour
    {
        [SerializeField]
        private Entity forInteractor = null;

        public Entity Interactor
        {
            get
            {
                return forInteractor;
            }
        }
    }
}
