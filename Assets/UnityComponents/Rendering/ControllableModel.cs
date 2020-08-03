using UnityEngine;

namespace Sakura.UnityComponents.Rendering
{
    [RequireComponent(typeof(UnityModel))]
    [RequireComponent(typeof(Transform))]
    public sealed class ControllableModel : MonoBehaviour
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
            if (Vector3.Distance(entity.Location, interpolatedPosition) > 0.1)
            {
                transform.position = interpolatedPosition;
            }
            else
            {
                transform.position = entity.Location;
            }
        }

        private void OnDestroy()
        {
            Destroy(unityModel);
        }
    }
}
