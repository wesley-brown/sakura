using Sakura.UI;
using UnityEngine;

namespace Sakura.UnityComponents.UI
{
    public sealed class DisplayingWindow : MonoBehaviour
    {
        [SerializeField] private GameObject window = null;

        private void Start()
        {
            Instantiate(window);
        }
    }
}
