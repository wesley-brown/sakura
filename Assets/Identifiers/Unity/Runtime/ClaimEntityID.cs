using System;
using Sakura.Identifiers.Client;
using UnityEngine;

namespace Sakura.Identifiers.Unity
{
    /// <summary>
    ///     Claim an entity ID for an attached game object.
    /// </summary>
    public sealed class ClaimEntityID : MonoBehaviour
    {
        /// <summary>
        ///     The entity ID to claim.
        /// </summary>
        [Tooltip("The entity ID to claim.")]
        public string entityID = "";

        /// <summary>
        ///     The ID registry to make the claim with.
        /// </summary>
        [Tooltip("The ID registry to make the claim with.")]
        public ScriptableObjectIdRegistry registry = null;

        private void Start()
        {
            Debug.Assert(entityID != "", "entityID must not be empty.");
            Debug.Assert(registry != null, "registry must not be null.");
            var claimsAuthority = new ClaimsAgent(registry);
            var ID = new Guid(entityID);
            if (!claimsAuthority.IsClaimed(ID))
                claimsAuthority.ClaimIDFor(ID, gameObject.GetInstanceID());
            else
                Debug.LogError("Entity ID '" + ID + "' is already claimed.");
        }
    }
}
