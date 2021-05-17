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

    [TestFixture]
    public class Identical_new_collisions
    {
        [Test]
        public void Have_the_same_hash_codes()
        {
            var collision = CreateCollision();
            var duplicateCollision = CreateCollision();
            Assert.AreEqual(
                duplicateCollision.GetHashCode(),
                collision.GetHashCode());
        }

        [Test]
        public void Are_equal()
        {
            var collision = CreateCollision();
            var duplicateCollision = CreateCollision();
            Assert.IsTrue(duplicateCollision.Equals(collision));
        }

        private Movement CreateMovement()
        {
            var ID = new Guid("9f255a1e-df00-41b1-9ccf-172c3c2a5575");
            var location = new Vector3(5.0f, 2.0f, 4.0f);
            var body = new Body(ID, location);
            var destination = new Vector3(5.0f, 3.0f, 4.0f);
            return Movement.For(body, destination);
        }

        private Body CreateBody()
        {
            var ID = new Guid("84e0df58-5d55-4716-b543-8f91a2250b5f");
            var location = new Vector3(5.0f, 3.0f, 4.0f);
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
