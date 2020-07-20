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
    [RequireComponent(typeof(WindowController))]
    public sealed class InventoryUI : MonoBehaviour
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
            Instantiate(HUD);
        }
    }
}
