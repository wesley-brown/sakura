using UnityEngine;

namespace Sakura
{
    [RequireComponent(typeof(SakuraInput))]
    public class EmptyPlotTest : MonoBehaviour
    {
        private void Awake()
        {
            sakuraInput = GetComponent<SakuraInput>();
        }

        private SakuraInput sakuraInput;

        private void FixedUpdate()
        {
            if (sakuraInput.HighlightedGameObject == gameObject)
            {
                Debug.Log($"[{gameObject.name}] I've been highlighted!");
            }
        }
    }
}
