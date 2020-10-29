using Sakura.UI.Windows;
using UnityEngine;

namespace Sakura.PlantSeed.UI
{
    [RequireComponent(typeof(WindowController))]
    public sealed class Screen : MonoBehaviour
    {
        [SerializeField] private GameObject HUD = null;

        public void Cancel()
        {
            Instantiate(HUD);
        }
    }
}
