using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Movement_Spec
{
    [TestFixture]
    public class Creating_a_movement_towards_a_destination_with_a_speed
    {
        [TestCase(-0.99f)]
        [TestCase(-1.0f)]
        [TestCase(float.MinValue)]
        public void Does_not_support_a_negative_speed(float speed)
        {
            var destination = new Vector3(2.0f, 0.0f, 0.0f);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Movement.TowardsDestinationWithSpeed(
                    destination,
                    speed);
            });
        }
    }

    [TestFixture]
    public class Moving_a_body
    {
        [Test]
        public void Moves_it_as_far_as_possible_in_one_tick()
        {
            var entity = new Guid("86f0373d-e578-4002-8636-3dd833781990");
            var entityLocation = new Vector3(0.0f, 0.0f, 0.0f);
            var body = Body.ForEntityLocatedAt(
                entity,
                entityLocation);
            var destination = new Vector3(2.0f, 0.0f, 0.0f);
            var speed = 1.0f;
            var movement = Movement.TowardsDestinationWithSpeed(
                destination,
                speed);
            var expectedLocation = new Vector3(1.0f, 0.0f, 0.0f);
            var movedBody = movement.Move(body);
            Assert.AreEqual(
                body.Entity,
                movedBody.Entity);
            Assert.AreEqual(
                expectedLocation,
                movedBody.Location);
        }
    }

    [TestFixture]
    public class The_string_representation_of_a_movement
    {
        [Test]
        public void Includes_its_destination()
        {
            var movement = CreateMovement();
            StringAssert.Contains(
                movement.Destination.ToString(),
                movement.ToString());
        }

        private static Movement CreateMovement()
        {
            var destination = new Vector3(3.0f, 0.0f, 0.0f);
            var speed = 1.0f;
            return Movement.TowardsDestinationWithSpeed(
                destination,
                speed);
        }

        [Test]
        public void Includes_its_speed()
        {
            var movement = CreateMovement();
            StringAssert.Contains(
                movement.Speed.ToString(),
                movement.ToString());
        }
    }
}
