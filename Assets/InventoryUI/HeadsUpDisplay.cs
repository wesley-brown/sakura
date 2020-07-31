using Sakura.UI;
using UnityEngine;

namespace Sakura.InventoryUI
{
    /// <summary>
    /// A heads up display that acts as the default UI for the player.
    /// </summary>
    [RequireComponent(typeof(WindowController))]
    public sealed class HeadsUpDisplay : MonoBehaviour
    {
        //private PlayerParameter playerParameter = null;
        [SerializeField] private GameObject inventoryUI = null;

        public void DisplayInventoryUI()
        {
            Instantiate(inventoryUI);
        }
    }
}
