using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sakura.Bodies.CollidableMovement.Data;

namespace In_Memory_Movement_Speeds_Spec
{
    [TestFixture]
    public class Creating_from_a_dictionary
    {
        [Test]
        public void Does_not_support_a_null_dictionary()
        {
            Dictionary<Guid, float> initialMovementSpeeds = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                InMemoryMovementSpeeds.From(initialMovementSpeeds);
            });
        }
    }
}
