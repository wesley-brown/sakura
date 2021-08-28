using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Movement_Temp_Spec
{
    [TestFixture]
    public class Creating_a_movement_for_a_body_and_location
    {
        [Test]
        public void Does_not_support_a_null_body()
        {
            BodyTemp body = null;
            var location = new Vector3(10.0f, 10.0f, 10.0f);
            Assert.Throws<ArgumentNullException>(() =>
            {
                MovementTemp.For(
                    body,
                    location);
            });
        }
    }

    [TestFixture]
    public class The_string_representation_of_a_movement
    {
        [Test]
        public void Includes_its_body()
        {
            var ID = new Guid("12c90c8a-9d7a-4a58-a9b3-f457496c9fba");
            var startingLocation = new Vector3(-5.0f, 0.0f, 0.0f);
            var body = BodyTemp.ForEntityLocatedAt(
                ID,
                startingLocation);
            var endingLocation = new Vector3(0.0f, 0.0f, 0.0f);
            var movement = MovementTemp.For(
                body,
                endingLocation);
            StringAssert.Contains(
                body.ToString(),
                movement.ToString());
        }
    }
}
