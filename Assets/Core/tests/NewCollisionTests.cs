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
            var ID = new Guid("b45ef316-b840-4bd6-9789-3f0a9ecf679c");
            var location = new Vector3(10.0f, 10.0f, 10.0f);
            var body = new Body(ID, location);
            Assert.Throws<ArgumentNullException>(() =>
            {
                new NewCollision(null, body);
            });
        }
    }
}
