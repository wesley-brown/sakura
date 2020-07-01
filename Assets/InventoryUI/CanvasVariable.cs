using UnityEngine;
using Sakura.Entities;

namespace Sakura
{
    public sealed class CanvasVariable : MonoBehaviour
    {
        [SerializeField]
        private Canvas @for = null;
        [SerializeField]
        private CanvasVariable referencing = null;

        private Canvas Canvas
        {
            get
            {
                if (@for != null)
                {
                    return @for;
                }
                else
                {
                    return referencing.Canvas;
                }
            }
        }

        public void Display(Prefab prefab)
        {
            Instantiate(prefab.Asset, Canvas.transform);
        }
    }
}
