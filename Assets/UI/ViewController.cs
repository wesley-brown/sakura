using UnityEngine;

namespace Sakura.UI
{
    public class ViewController : MonoBehaviour
    {
        public Window Window = null;

        protected virtual void Start()
        {

            if (Window != null)
            {
                Window.Display(gameObject);
            }
            //Window.Display(gameObject);
        }
    }
}
