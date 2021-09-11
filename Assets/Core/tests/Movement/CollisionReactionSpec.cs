using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Collision_Reaction_Spec
{
    [TestFixture]
    public class Creating_a_collision_reaction_for_two_collided_bodies
    {
        [Test]
        public void Does_not_support_a_null_collider_body()
        {
            BodyTemp collidersBody = null;
            var collidee = new Guid("8910b086-e969-48f4-b915-89bc8fe4432f");
            var collideesLocation = new Vector3(5.0f, 0.0f, 0.0f);
            var collideesBody = BodyTemp.ForEntityLocatedAt(
                collidee,
                collideesLocation);
            Assert.Throws<ArgumentNullException>(() =>
            {
                CollisionReaction.ForCollidedBodies(
                    collidersBody,
                    collideesBody);
            });
        }
    }
}
