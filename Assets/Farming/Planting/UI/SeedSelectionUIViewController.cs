using Sakura.UI.Windows;
using UnityEngine;

namespace Sakura.InventoryUI
{
    [RequireComponent(typeof(WindowController))]
    public sealed class SeedSelectionUIViewController : MonoBehaviour
    {
        [SerializeField] private GameObject HUD = null;

        public void Cancel()
        {
            Instantiate(HUD);
        }
    }
}
