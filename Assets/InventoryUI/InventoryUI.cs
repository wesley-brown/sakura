using Sakura.Entities;
using Sakura.UI;
using UnityEngine;

namespace Sakura.InventoryUI
{
    /// <summary>
    /// A UI for the player's inventory.
    /// </summary>
    [RequireComponent(typeof(GameObjectParameter))]
    [RequireComponent(typeof(PlayerParameter))]
    public sealed class InventoryUI : WindowController
    {
        private PlayerParameter playerParameter = null;
        [SerializeField] private GameObject HUD = null;

        private void Awake()
        {
            playerParameter = GetComponent<PlayerParameter>();
        }

        /// <summary>
        /// Unfreeze the player.
        /// </summary>
        public void UnfreezePlayer()
        {
            playerParameter.Value.Unfreeze();
        }

        public void DisplayHUD()
        {
            Window.Display(HUD);
        }
    }
}
