using UnityEngine;
using Sakura.Interactions;
using Sakura.Inventories.Runtime;

namespace Sakura.Runtime
{
    public sealed class InteractablePlantableSoil : MonoBehaviour, Reaction
    {
        [SerializeField]
        private InventoryReference playerInventoryReference = null;

        [SerializeField]
        private GameObject potatoCropPrefab = null;

        public void React()
        {
            var playersInventory = playerInventoryReference.Inventory;
            var potatoSeed = new InventoryItem("Potato Seed");
            if (playersInventory.Contains(potatoSeed))
            {
                playersInventory.RemoveFirstInstanceOfItem(potatoSeed);
                Instantiate(
                    potatoCropPrefab,
                    transform.position,
                    transform.rotation
                );
            }
        }
    }
}
