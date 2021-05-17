using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Collision_spec
{
    [TestFixture]
    public class A_collision
    {
        [Test]
        public void Throws_when_created_without_a_colliding_body()
        {
            var otherBody = CreateBody();
            Assert.Throws<ArgumentNullException>(() =>
            {
                Sakura.Core.Collision.ForBodyCollidingWithOther(
                    null,
                    otherBody);
            });
        }

        [Test]
        public void Throws_when_created_without_another_body()
        {
            var body = CreateBody();
            Assert.Throws<ArgumentNullException>(() =>
            {
                Sakura.Core.Collision.ForBodyCollidingWithOther(
                    body,
                    null);
            });
        }

        [Test]
        public void Has_a_custom_string_representation()
        {
            var body = CreateBody();
            var otherBody = CreateOtherBody();
            var collision = Sakura.Core.Collision.ForBodyCollidingWithOther(
                body,
                otherBody);
            var expectedString = "{"
                + "Collider="
                + collision.Collider()
                + ", Other="
                + collision.Other()
                + "}";
            Assert.AreEqual(
                expectedString,
                collision.ToString());
        }

        private Body CreateBody()
        {
            var ID = new Guid("b45ef316-b840-4bd6-9789-3f0a9ecf679c");
            var location = new Vector3(10.0f, 10.0f, 10.0f);
            return new Body(ID, location);
        }

        private Body CreateOtherBody()
        {
            var ID = new Guid("bbf70d97-8dc7-4219-99e6-75da8741cdc9");
            var location = new Vector3(9.0f, 10.0f, 10.0f);
            return new Body(ID, location);
        }
    }
}
