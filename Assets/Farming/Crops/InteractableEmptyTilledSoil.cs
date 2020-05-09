using UnityEngine;
using Sakura.Interactions;

namespace Sakura.Crop
{
    public sealed class InteractableEmptyTilledSoil : MonoBehaviour,
        Reaction
    {
        [SerializeField]
        private GameObject plantableTilledSoilPrefab = null;

        public void React()
        {
            Instantiate(
                plantableTilledSoilPrefab,
                transform.position,
                transform.rotation
            );
        }
    }
}
