using System;
using UnityEngine;

namespace Sakura.Identifiers.Client
{
    /// <summary>
    ///     Keeps track of entity IDs and which game objects have claimed 
    ///     them.
    /// </summary>
    public interface IdRegistry
    {
        /// <summary>
        ///     Retrieve the game object, if any, claiming a given entity ID.
        /// </summary>
        /// <param name="ID">
        ///     The entity ID to retrieve the claiming game object of.
        /// </param>
        /// <returns>
        ///     The game object claiming the given entity ID, if one exists;
        ///     null otherwise.
        /// </returns>
        GameObject GameObjectClaimingId(Guid ID);

        /// <summary>
        ///     Claim a given entity ID for a game object with a given instance
        ///     ID.
        /// </summary>
        /// <param name="ID">
        ///     The entity ID to claim.
        /// </param>
        /// <param name="gameObject">
        ///     The instance ID of the game object to make the claim for.
        /// </param>
        void ClaimIdFor(Guid ID, int instanceID);
    }
}
