using Sakura.UnityComponents.Rendering;
using UnityEngine;

namespace Sakura
{
    /// <summary>
    /// A 3D representation of an entity rendered in Unity.
    /// </summary>
    [RequireComponent(typeof(UnityModel))]
    public sealed class UncontrollableModel : MonoBehaviour
    {
        private UnityModel unityModel = null;

        private void Awake()
        {
            unityModel = GetComponent<UnityModel>();
        }

        private void Update()
        {
            var entity = unityModel.Entity;
            var interpolatedPosition = Vector3.Lerp(transform.position, entity.Location, Time.deltaTime);
            transform.position = interpolatedPosition;
        }

        private void OnDestroy()
        {
            Destroy(unityModel);
        }
    }
}
