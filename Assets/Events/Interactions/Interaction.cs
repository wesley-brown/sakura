using UnityEngine;

namespace Sakura.Events.Interactions
{
    public sealed class Interaction
    {
        private readonly GameObject interactor;

        public Interaction(GameObject interactor)
        {
            this.interactor = interactor;
        }

        public GameObject Interactor
        {
            get
            {
                return interactor;
            }
        }
    }
}
