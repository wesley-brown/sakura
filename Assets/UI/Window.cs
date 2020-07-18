using UnityEngine;

namespace Sakura.UI
{
    public sealed class Window
    {
        private ViewController contentViewController;

        public Window(ViewController viewController)
        {
            contentViewController = viewController;
            //Display(viewController.gameObject);
        }

        public void Display(GameObject view)
        {
            //if (contentViewController)
            //{
            //    Object.Destroy(contentViewController.gameObject);
            //}
            // Actually display the "view" in the current scene
            //var contentView = Object.Instantiate(view);
            view.SetActive(true);
            contentViewController = view.GetComponent<ViewController>();
            contentViewController.Window = this;
        }
    }
}
