using System;
using System.Collections.Generic;
using Sakura.Identifiers.Client;
using UnityEngine;

namespace Sakura.Identifiers.Infrastructure
{
    /// <summary>
    ///     An ID registry that uses an internal dictionary to keep track of
    ///     entity ID claims.
    /// </summary>
    public sealed class DictionaryIdRegistry : IdRegistry
    {
        private readonly Dictionary<Guid, GameObject> claims;

        /// <summary>
        ///     Create a new dictionary ID registry.
        /// </summary>
        public DictionaryIdRegistry()
        {
            claims = new Dictionary<Guid, GameObject>();
        }

        public GameObject GameObjectClaimingId(Guid ID)
        {
            if (claims.ContainsKey(ID))
                return claims[ID];
            else
                return null;

        }

        public void ClaimIdFor(Guid ID, int instanceID)
        {
            var gameObjects =
                UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (var gameObject in gameObjects)
                if (gameObject.GetInstanceID() == instanceID)
                    claims[ID] = gameObject;
        }
    }
}
