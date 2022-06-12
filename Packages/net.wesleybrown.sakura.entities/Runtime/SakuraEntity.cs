using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Entities
{
    /// <summary>
    ///     Marks an attached Unity game object as representing a Sakura
    ///     entity.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class SakuraEntity : MonoBehaviour
    {
        private static readonly Dictionary<Guid, GameObject> gameObjects =
            new Dictionary<Guid, GameObject>();

        public static Dictionary<Guid, GameObject> GameObjects
        {
            get
            {
                return gameObjects;
            }
        }

        [Tooltip("The ID of the entity the attached Unity game object"
            + " represents.")]
        public string ID;

        private void Start()
        {
            var isGuid = Guid.TryParse(
                ID,
                out idAsGuid);
            if (!isGuid)
            {
                Debug.LogError(
                    $"The ID '{ID}' is not a GUID."
                        + $" Game object '{gameObject.name}'"
                        + " could not be bound to a Sakura entity.",
                    gameObject);
                return;
            }
            if (gameObjects.ContainsKey(idAsGuid))
            {
                Debug.LogError(
                    $"Could not bind game object '{gameObject.name}' to entity '{ID}'. That entity has already been bound to another game object.",
                    gameObject);
            }
            else
            {
                gameObjects[idAsGuid] = gameObject;
                Debug.Log(
                    $"Bound game object '{gameObject.name}' to entity '{ID}'.",
                    gameObject);
            }
        }

        private Guid idAsGuid;

        public Guid? IDasGuid
        {
            get
            {
                if (idAsGuid != Guid.Empty)
                {
                    return idAsGuid;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
