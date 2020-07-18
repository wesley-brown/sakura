using Sakura.UI;
using UnityEngine;

namespace Sakura.InventoryUI
{
    /// <summary>
    /// A heads up display that acts as the default UI for the player.
    /// </summary>
    [RequireComponent(typeof(PlayerParameter))]
    public sealed class HeadsUpDisplay : WindowController
    {
        private PlayerParameter playerParameter = null;
        [SerializeField] private GameObject inventoryUI = null;

        private void Awake()
        {
            playerParameter = GetComponent<PlayerParameter>();
        }

        protected override void Start()
        {
            base.Start();
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
            Window.Display(inventoryUI);
        }
    }
}
