using UnityEngine.EventSystems;

namespace Sakura.Instantiation.UI.Windows
{
    public interface WindowCreationHandler : IEventSystemHandler
    {
        void OnWindowCreated(WindowCreated windowCreated);
    }
}
