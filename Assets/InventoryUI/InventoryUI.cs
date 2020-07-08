using Sakura.Entities;
using UnityEngine;

namespace Sakura.InventoryUI
{
    /// <summary>
    /// A UI for the player's inventory.
    /// </summary>
    [RequireComponent(typeof(GameObjectParameter))]
    [RequireComponent(typeof(PlayerParameter))]
    public sealed class InventoryUI : MonoBehaviour
    {
        private PlayerParameter playerParameter = null;

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
    }
}
