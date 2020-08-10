using Sakura.Interactions.Conditions;
using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// An interaction.
    /// </summary>
    [RequireComponent(typeof(Transform))]
    public sealed class Interaction : MonoBehaviour
    {
        [SerializeField] private GameObject reaction = null;
        private Condition[] conditions = null;

        private void Awake()
        {
            conditions = GetComponents<Condition>();
        }

        public void React()
        {
            var allConditionsHaveBeenMet = true;
            foreach (var condition in conditions)
            {
                if (!condition.IsTrue)
                {
                    allConditionsHaveBeenMet = false;
                }
            }
            if (allConditionsHaveBeenMet)
            {
                Instantiate(reaction, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
