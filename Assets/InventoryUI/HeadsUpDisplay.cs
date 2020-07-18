using Sakura.UI;
using UnityEngine;

namespace Sakura.InventoryUI
{
    /// <summary>
    /// A heads up display that acts as the default UI for the player.
    /// </summary>
    [RequireComponent(typeof(PlayerParameter))]
    public sealed class HeadsUpDisplay : ViewController
    {
        private PlayerParameter playerParameter = null;
        [SerializeField] private GameObject inventoryUI = null;

        private void Awake()
        {
            playerParameter = GetComponent<PlayerParameter>();
        }

        /// <summary>
        /// Freeze the player.
        /// </summary>
        public void FreezePlayer()
        {
            playerParameter.Value.Freeze();
        }

        public void DisplayInventoryUI()
        {
            var temp = Instantiate(inventoryUI);
            Window.Display(temp);
        }
    }
}
