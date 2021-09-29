using System;
using NUnit.Framework;
using Sakura.Bodies.Core;
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
    public class Moving_a_body_towards_a_destination_too_slowly
    {
        [TestCaseSource(nameof(Cases))]
        public void Moves_it_as_close_as_possible_in_one_tick(
            Vector3 startingLocation,
            Vector3 destination,
            float speed,
            Vector3 expectedLocation)
        {
            var entity = new Guid("86f0373d-e578-4002-8636-3dd833781990");
            var body = Body.ForEntityLocatedAt(
                entity,
                startingLocation);
            var movement = Movement.TowardsDestinationWithSpeed(
                destination,
                speed);
            var movedBody = movement.Move(body);
            Assert.AreEqual(
                entity,
                movedBody.Entity);
            Assert.AreEqual(
                expectedLocation,
                movedBody.Location);
        }

        static readonly object[] Cases =
        {
            // x-axis aligned movement
            new object[]
            {
                new Vector3(0.0f, 0.0f, 0.0f),  // starting location
                new Vector3(2.0f, 0.0f, 0.0f),  // destination
                1.0f,                           // speed
                new Vector3(1.0f, 0.0f, 0.0f)   // ending location
            },

            // z-axis aligned movement
            new object[]
            {
                new Vector3(0.0f, 0.0f, 0.0f),  // starting location
                new Vector3(0.0f, 0.0f, 2.0f),  // destination
                1.0f,                           // speed
                new Vector3(0.0f, 0.0f, 1.0f)   // ending location
            },

            // x-axis and z-axis movement
            new object[]
            {
                new Vector3(0.0f, 0.0f, 0.0f),  // starting location
                new Vector3(2.0f, 0.0f, 2.0f),  // destination
                1.0f,                           // speed
                new Vector3(
                    (float)Math.Sqrt(8)/4,
                    0.0f,
                    (float)Math.Sqrt(8)/4)      // ending location
            },

            // x-axis, y-axis, and z-axis movement
            new object[]
            {
                new Vector3(-5.0f, -5.0f, -5.0f),       // starting location
                new Vector3(-3.0f, -3.0f, -3.0f),       // destination
                1.0f,                                   // speed
                new Vector3(
                    -5 + (float)(Math.Sqrt(3) / 3),
                    -5 + (float)(Math.Sqrt(3) / 3),
                    -5 + (float)(Math.Sqrt(3) / 3))     // ending location
            }
        };
    }

    [TestFixture]
    public class Moving_a_body_towards_a_destination_exactly_fast_enough
    {
        [TestCaseSource(nameof(Cases))]
        public void Moves_it_to_the_destination_in_one_tick(
            Vector3 startingLocation,
            Vector3 destination,
            float speed,
            Vector3 expectedLocation)
        {
            var entity = new Guid("862fb4eb-0154-4ad7-913b-916341af4f12");
            var body = Body.ForEntityLocatedAt(
                entity,
                startingLocation);
            var movement = Movement.TowardsDestinationWithSpeed(
                destination,
                speed);
            var movedBody = movement.Move(body);
            Assert.AreEqual(
                movedBody.Entity,
                entity);
            Assert.AreEqual(
                expectedLocation,
                movedBody.Location);
        }

        static readonly object[] Cases =
        {
            // x-axis aligned movement
            new object[]
            {
                new Vector3(0.0f, 0.0f, 0.0f),  // starting location
                new Vector3(1.0f, 0.0f, 0.0f),  // destination
                1.0f,                           // speed
                new Vector3(1.0f, 0.0f, 0.0f)   // ending location
            },

            // z-axis aligned movement
            new object[]
            {
                new Vector3(0.0f, 0.0f, -1.0f), // starting location
                new Vector3(0.0f, 0.0f, 1.0f),  // destination
                2.0f,                           // speed
                new Vector3(0.0f, 0.0f, 1.0f)   // ending location
            },

            // x-axis and z-axis aligned movement
            new object[]
            {
                new Vector3(-10.0f, 0.0f, 10.0f),   // starting location
                new Vector3(10.0f, 0.0f, -10.0f),   // destination
                20 * (float)Math.Sqrt(2),           // speed
                new Vector3(10.0f, 0.0f, -10.0f)    // ending location
            },

            // x-axis, y-axis, and z-axis movement
            new object[]
            {
                new Vector3(-1.5f, -1.5f, -1.5f),   // starting location
                new Vector3(-4.5f, -4.5f, -4.5f),   // destination
                3 * (float)Math.Sqrt(3),            // speed
                new Vector3(-4.5f, -4.5f, -4.5f)    // ending location
            }
        };
    }

    [TestFixture]
    public class Moving_a_body_towards_a_destination_faster_than_necessary
    {
        [TestCaseSource(nameof(Cases))]
        public void Moves_it_only_to_the_destination_in_one_tick(
            Vector3 startingLocation,
            Vector3 destination,
            float speed,
            Vector3 expectedLocation)
        {
            var entity = new Guid("726946e3-9a3f-44ef-a067-0b638fd20d86");
            var body = Body.ForEntityLocatedAt(
                entity,
                startingLocation);
            var movement = Movement.TowardsDestinationWithSpeed(
                destination,
                speed);
            var movedBody = movement.Move(body);
            Assert.AreEqual(
                movedBody.Entity,
                entity);
            Assert.AreEqual(
                expectedLocation,
                movedBody.Location);
        }

        static readonly object[] Cases =
        {
            // x-axis aligned movement
            new object[]
            {
                new Vector3(0.0f, 0.0f, 0.0f),  // starting location
                new Vector3(1.0f, 0.0f, 0.0f),  // destination
                10.0f,                          // speed
                new Vector3(1.0f, 0.0f, 0.0f)   // ending location
            },

            // z-axis aligned movement
            new object[]
            {
                new Vector3(0.0f, 0.0f, 0.5f),  // starting location
                new Vector3(0.0f, 0.0f, -0.5f), // destination
                123.45f,                        // speed
                new Vector3(0.0f, 0.0f, -0.5f)  // ending location
            },

            // x-axis and z-axis aligned movement
            new object[]
            {
                new Vector3(4.0f, 0.0f, 6.0f),  // starting location
                new Vector3(3.0f, 0.0f, -6.0f), // destination
                2000.12f,                       // speed
                new Vector3(3.0f, 0.0f, -6.0f)  // ending location
            },

            // x-axis, y-axis, and z-axis movement
            new object[]
            {
                new Vector3(1.0f, -2.0f, 3.0f), // starting location
                new Vector3(10.0f, 2.0f, 6.0f), // destination
                1847.73f,                       // speed
                new Vector3(10.0f, 2.0f, 6.0f)  // ending location
            }
        };
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
