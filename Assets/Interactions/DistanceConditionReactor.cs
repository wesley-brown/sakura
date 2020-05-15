using UnityEngine;
using UnityEngine.Events;

namespace Sakura.Interactions
{
    /// <summary>
    /// Causes a game object to react to being interacted with when any game 
    /// object with a given tag is within a certain distance.
    /// </summary>
    public sealed class DistanceConditionReactor : MonoBehaviour, Reactor
    {
        [SerializeField]
        private string tagToCheckFor = "";

        [SerializeField]
        private float maximumDistance = 0.0f;

        [SerializeField]
        private UnityEvent whenIsCloseEnough = null;

        public void React()
        {
            var otherGameObjectsWithTag = GameObject
                .FindGameObjectsWithTag(tagToCheckFor);
            foreach (var otherGameObject in otherGameObjectsWithTag)
            {
                var vectorBetweenThisAndOther =
                    otherGameObject.transform.position - transform.position;
                if (vectorBetweenThisAndOther.magnitude <= maximumDistance)
                {
                    whenIsCloseEnough.Invoke();
                }
            }

        }
    }
}
