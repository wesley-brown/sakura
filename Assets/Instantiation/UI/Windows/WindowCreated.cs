using UnityEngine;

namespace Sakura.Instantiation.UI.Windows
{
    public sealed class WindowCreated
    {
        public WindowCreated(GameObject creator)
        {
            Creator = creator;
        }

        public GameObject Creator { get; }
    }
}
