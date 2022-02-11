using System;
using UnityEngine;

namespace Sakura
{
    /// <summary>
    ///     Configuration that specifies the entity that the attached
    ///     <see cref="GameObject"/> represents.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class SakuraEntity : MonoBehaviour
    {
        /// <summary>
        ///     The ID of the entity the attached <see cref="GameObject"/>
        ///     represents.
        /// </summary>
        public string ID;

        private void Start()
        {
            var isGuid = Guid.TryParse(ID, out _);
            if (!isGuid)
                Debug.LogError("The given ID is not a GUID.");
        }
    }
}
