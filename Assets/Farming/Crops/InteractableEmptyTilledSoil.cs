using UnityEngine;
using Sakura.Runtime;

namespace Sakura.Crop
{
    public sealed class InteractableEmptyTilledSoil : MonoBehaviour,
        Interactable
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
            Destroy(gameObject);
        }
    }
}