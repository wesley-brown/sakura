using Sakura.UnityComponents.Rendering;
using UnityEngine;

namespace Sakura.Interactions.Conditions
{
    public sealed class PlayerIsWithinXMeters : MonoBehaviour, Condition
    {
        [SerializeField] private float meters = 0.0f;

        public bool IsTrue
        {
            get
            {
                var player = GameObject
                    .FindGameObjectWithTag("Player")
                    .GetComponent<UnityModel>()
                    .Entity;
                var distance = Vector3.Distance(
                    player.Location,
                    transform.position);
                return distance <= meters;
            }
        }
    }
}
