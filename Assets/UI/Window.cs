using UnityEngine;

namespace Sakura.UI
{
    public sealed class Window
    {
        private WindowController mainWindowController;

        public Window(WindowController windowController)
        {
            mainWindowController = windowController;
            mainWindowController.Window = this;
        }

        public void Display(GameObject view)
        {
            Object.Destroy(mainWindowController.gameObject);
            var contentView = Object.Instantiate(view);
            contentView.SetActive(true);
            mainWindowController = contentView.GetComponent<WindowController>();
            mainWindowController.Window = this;
        }
    }
}
