using System;
using NUnit.Framework;
using UnityEngine;

namespace Sakura.Core.Tests
{
    [TestFixture]
    public class A_collision
    {
        [Test]
        public void Throws_when_created_without_a_colliding_body()
        {
            var ID = new Guid("b45ef316-b840-4bd6-9789-3f0a9ecf679c");
            var location = new Vector3(10.0f, 10.0f, 10.0f);
            var otherBody = new Body(ID, location);
            Assert.Throws<ArgumentNullException>(() =>
            {
                Collision.ForBodyCollidingWithOther(
                    null,
                    otherBody);
            });
        }
    }
}
