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

    [TestFixture]
    public class The_movement_speed
    {
        [Test]
        public void For_an_entity_that_does_not_exist_is_zero()
        {
            var movementSpeeds = InMemoryMovementSpeeds.Empty();
            var entity = new Guid("8015ce2b-621c-4c16-81a7-8b248bf6ce69");
            var movementSpeed = movementSpeeds.MovementSpeedForEntity(entity);
            Assert.AreEqual(
                0.0f,
                movementSpeed);
        }
    }
}
