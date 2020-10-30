using Sakura.UI;
using UnityEngine;

namespace Sakura.PlantSeed.UI
{
    public sealed class Screen : MonoBehaviour
    {
        [SerializeField] private GameObject HUD = null;
        private Window window = null;

        private void Awake()
        {
            window = GetComponent<Window>();
        }

        public void Cancel()
        {
            window.Close();
        }
    }
}
