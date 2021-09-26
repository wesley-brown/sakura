using System;
using NUnit.Framework;
using Sakura.Data;

namespace In_Memory_Collidable_Bodies_Spec
{
    [TestFixture]
    public class Creating_with_collections
    {
        [Test]
        public void Does_not_support_a_null_collection_of_movement_speeds()
        {
            MovementSpeeds movementSpeeds = null;
            var bodies = new DummyBodies();
            var collisions = new DummyCollisions();
            Assert.Throws<ArgumentNullException>(() =>
            {
                InMemoryCollidableBodies.WithCollections(
                    movementSpeeds,
                    bodies,
                    collisions);
            });
        }
    }
}
