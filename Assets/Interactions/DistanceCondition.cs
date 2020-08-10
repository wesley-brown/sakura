using UnityEngine;
using Sakura.Interactions;

namespace Sakura
{
    /// <summary>
    /// A condition based on the distance from a game object with a given tag.
    /// </summary>
    public sealed class DistanceCondition : Condition
    {
        [SerializeField]
        private string tagToCheckFor = "";
        [SerializeField]
        private float maximumDistance = 0.0f;

        public override bool IsTrue
        {
            get
            {
                var target = GameObject.FindGameObjectWithTag(tagToCheckFor);
                var distance =
                    target.transform.position - transform.position;
                Destroy(this);
                return distance.magnitude <= maximumDistance;
            }
        }
    }
}
