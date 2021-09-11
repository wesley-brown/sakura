﻿using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Movement_Spec
{
    [TestFixture]
    public class Creating_a_movement_for_a_body_and_destination
    {
        [Test]
        public void Does_not_support_a_null_body()
        {
            Body body = null;
            var destination = new Vector3(10.0f, 10.0f, 10.0f);
            Assert.Throws<ArgumentNullException>(() =>
            {
                Movement.For(
                    body,
                    destination);
            });
        }
    }

    [TestFixture]
    public class The_string_representation_of_a_movement
    {
        [Test]
        public void Includes_its_body()
        {
            var movement = Movement();
            StringAssert.Contains(
                movement.Body.ToString(),
                movement.ToString());
        }

        [Test]
        public void Includes_its_resulting_body()
        {
            var movement = Movement();
            StringAssert.Contains(
                movement.ResultingBody().ToString(),
                movement.ToString());
        }

        private static Movement Movement()
        {
            var ID = new Guid("12c90c8a-9d7a-4a58-a9b3-f457496c9fba");
            var startingLocation = new Vector3(-5.0f, 0.0f, 0.0f);
            var body = Body.ForEntityLocatedAt(
                ID,
                startingLocation);
            var destination = new Vector3(0.0f, 0.0f, 0.0f);
            return Sakura.Core.Movement.For(
                body,
                destination);
        }
    }
}
