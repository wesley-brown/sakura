using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace New_collision_spec
{
    [TestFixture]
    public class A_new_collision
    {
        [Test]
        public void Throws_when_created_without_a_movement()
        {
            var body = CreateBody();
            Assert.Throws<ArgumentNullException>(() =>
            {
                new NewCollision(
                    null,
                    body);
            });
        }

        [Test]
        public void Throws_when_created_without_a_body()
        {
            var movement = CreateMovement();
            Assert.Throws<ArgumentNullException>(() =>
            {
                new NewCollision(
                    movement,
                    null);
            });
        }

        [Test]
        public void Has_a_custom_string_representation()
        {
            var collision = CreateCollision();
            var expectedString = "{"
                + "Movement="
                + collision.Movement()
                + ", Body="
                + collision.Body()
                + "}";
            Assert.AreEqual(expectedString, collision.ToString());
        }

        private Movement CreateMovement()
        {
            var ID = new Guid("b45ef316-b840-4bd6-9789-3f0a9ecf679c");
            var location = new Vector3(10.0f, 10.0f, 10.0f);
            var body = new Body(ID, location);
            var destination = new Vector3(9.0f, 10.0f, 10.0f);
            return Movement.For(body, destination);
        }

        private Body CreateBody()
        {
            var ID = new Guid("bbf70d97-8dc7-4219-99e6-75da8741cdc9");
            var location = new Vector3(9.0f, 10.0f, 10.0f);
            return new Body(ID, location);
        }

        private NewCollision CreateCollision()
        {
            return new NewCollision(
                CreateMovement(),
                CreateBody());
        }
    }
}
