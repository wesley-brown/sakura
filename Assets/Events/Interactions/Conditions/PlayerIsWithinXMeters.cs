using Sakura.UnityComponents.Rendering;
using UnityEngine;

namespace Sakura.Events.Interactions.Conditions
{
    [RequireComponent(typeof(MainHook))]
    public sealed class PlayerIsWithinXMeters :
        MonoBehaviour,
        ConditionCheckReceiver
    {
        [SerializeField] private float meters = 0.0f;

        private MainHook mainHook = null;

        private void Awake()
        {
            mainHook = GetComponent<MainHook>();
        }

        public void Receive(Condition condition)
        {
            var distance = Vector3.Distance(
                transform.position,
                mainHook.Player.Location);
            if (distance > meters)
            {
                condition.HasNotBeenMet();
            }
        }
    }
}
