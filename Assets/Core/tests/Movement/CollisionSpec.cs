using System;
using NUnit.Framework;
using Sakura.Core;

namespace Collision_Spec
{
    [TestFixture]
    public class Creating_a_collision_between_two_bodies
    {
        [Test]
        public void Does_not_support_a_null_collider_body()
        {
            Body colliderBody = null;
            var collidee = new Guid("0a35997f-1c46-426d-a9ee-dcbca907cae9");
            var collideeLocation = new UnityEngine.Vector3(5.0f, 0.0f, 0.0f);
            var colideeBody = Body.ForEntityLocatedAt(
                collidee,
                collideeLocation);
            Assert.Throws<ArgumentNullException>(() =>
            {
                Collision.BetweenBodies(
                    colliderBody,
                    colliderBody);
            });
        }

        [Test]
        public void Does_not_support_a_null_collidee_body()
        {
            var collider = new Guid("db8956a2-2b44-40a8-ab9e-8e0e4f064220");
            var colliderLocation = new UnityEngine.Vector3(3.0f, 0.0f, 0.0f);
            var colliderBody = Body.ForEntityLocatedAt(
                collider,
                colliderLocation);
            Body collideeBody = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Collision.BetweenBodies(
                    colliderBody,
                    collideeBody);
            });
        }
    }
}
