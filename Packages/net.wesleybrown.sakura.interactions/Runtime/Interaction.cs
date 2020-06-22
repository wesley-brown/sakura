using UnityEngine;

namespace Sakura.Interactions
{
    /// <summary>
    /// An interaction.
    /// </summary>
    [RequireComponent(typeof(Reaction))]
    public sealed class Interaction : MonoBehaviour
    {
        private Condition[] conditions = null;
        private Reaction reaction = null;

        private void Awake()
        {
            conditions = GetComponentsInChildren<Condition>();
            reaction = GetComponentInChildren<Reaction>();
        }

        public void Interact()
        {
            bool allConditionsMet = true;
            foreach (var condition in conditions)
            {
                if (!condition.IsTrue)
                {
                    allConditionsMet = false;
                    break;
                }
            }

            if (allConditionsMet)
            {
                reaction.React();
            }
        }
    }
}
