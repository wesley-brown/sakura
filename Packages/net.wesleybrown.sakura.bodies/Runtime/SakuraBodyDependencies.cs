using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Bodies
{
    /// <summary>
    ///     The necessary dependencies for all the systems a
    ///     <see cref="Player"/> can create.
    /// </summary>
    [CreateAssetMenu]
    public sealed class SakuraBodyDependencies : ScriptableObject
    {
        [NonSerialized]
        public Dictionary<Guid, Vector3> bodies =
            new Dictionary<Guid, Vector3>();
        [NonSerialized]
        public Dictionary<Guid, float> movementSpeeds =
            new Dictionary<Guid, float>();
        [NonSerialized]
        public Dictionary<Guid, GameObject> gameObjects =
            new Dictionary<Guid, GameObject>();
    }
}
