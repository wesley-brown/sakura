using Sakura.Events.Interactions.Conditions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sakura.Events.Interactions
{
    public sealed class Interactable : MonoBehaviour, InteractionReceiver
    {
        public void Receive(Interaction interaction)
        {
            var condition = new Condition();
            ExecuteEvents.Execute<ConditionCheckReceiver>(
                gameObject,
                null,
                (conditionCheckReceiver, eventData) => {
                    conditionCheckReceiver.Receive(condition);
                });
            if (condition.IsTrue)
            {
                ExecuteEvents.Execute<SuccessfulInteractionReceiver>(
                    gameObject,
                    null,
                    (successfulInteractionReceiver, eventData) => {
                        successfulInteractionReceiver.Receive();
                    });
            }
        }
    }
}
