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

        [Test]
        public void Does_not_support_a_null_collidee_body()
        {
            var collider = new Guid("dc17cb7a-10d8-4ed4-b36d-a08ff275d049");
            var collidersLocation = new Vector3(4.0f, 0.0f, 0.0f);
            var collidersBody = BodyTemp.ForEntityLocatedAt(
                collider,
                collidersLocation);
            BodyTemp collideesBody = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                CollisionReaction.ForCollidedBodies(
                    collidersBody,
                    collideesBody);
            });
        }
    }

    [TestFixture]
    public class The_string_representation_of_a_collision_reaction
    {
        [Test]
        public void Contains_its_collider_body()
        {
            var collider = new Guid("dc17cb7a-10d8-4ed4-b36d-a08ff275d049");
            var collidersLocation = new Vector3(4.0f, 0.0f, 0.0f);
            var collidersBody = BodyTemp.ForEntityLocatedAt(
                collider,
                collidersLocation);
            var collidee = new Guid("8910b086-e969-48f4-b915-89bc8fe4432f");
            var collideesLocation = new Vector3(5.0f, 0.0f, 0.0f);
            var collideesBody = BodyTemp.ForEntityLocatedAt(
                collidee,
                collideesLocation);
            var collisionReaction = CollisionReaction.ForCollidedBodies(
                collidersBody,
                collideesBody);
            StringAssert.Contains(
                collisionReaction.Collider.ToString(),
                collisionReaction.ToString());
        }
    }
}
