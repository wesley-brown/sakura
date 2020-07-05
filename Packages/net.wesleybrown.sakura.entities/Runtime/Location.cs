using UnityEngine;

namespace Sakura.Entities
{
    /// <summary>
    /// Where a game object exists in the world.
    /// </summary>
    [RequireComponent(typeof(GameObjectParameter))]
    public sealed class Location : MonoBehaviour
    {
        private GameObjectParameter gameObjectParameter = null;
        private Vector3 value = Vector3.zero;

        private void Awake()
        {
            gameObjectParameter = GetComponent<GameObjectParameter>();
            value = gameObjectParameter.gameObject.transform.position;
        }

        public Vector3 Coordinates
        {
            get
            {
                return value;
            }
        }
    }
}
