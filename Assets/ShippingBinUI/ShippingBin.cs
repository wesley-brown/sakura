using UnityEngine;
using Sakura.Entities;

namespace Sakura
{
    [RequireComponent(typeof(CanvasVariable))]
    public sealed class ShippingBin : MonoBehaviour
    {
        private CanvasVariable canvas = null;

        private void Awake()
        {
            canvas = GetComponent<CanvasVariable>();
        }

        public void Test(GameObject gameObject)
        {

        }
    }
}
