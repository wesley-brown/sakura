using System;
using NUnit.Framework;
using Sakura.Core;

namespace Collision_Spec
{
    [TestFixture]
    public class Creating_a_collision_with_an_adjusted_movement_towards_a_target_body
    {
        [Test]
        public void Does_not_support_a_null_movement()
        {
            Movement movement = null;
            var entity = new Guid("0a35997f-1c46-426d-a9ee-dcbca907cae9");
            var location = new UnityEngine.Vector3(5.0f, 0.0f, 0.0f);
            var body = Body.ForEntityLocatedAt(
                entity,
                location);
            Assert.Throws<ArgumentNullException>(() =>
            {
                Collision.WithAdjustedMovementTowardsTargetBody(
                    movement,
                    body);
            });
        }

        [Test]
        public void Does_not_support_a_null_body()
        {
            var player = new Guid("db8956a2-2b44-40a8-ab9e-8e0e4f064220");
            var playersLocation = new UnityEngine.Vector3(3.0f, 0.0f, 0.0f);
            var playersBody = Body.ForEntityLocatedAt(
                player,
                playersLocation);
            var playersAdjustedDestination =
                new UnityEngine.Vector3(4.0f, 0.0f, 0.0f);
            var playersAdjustedMovement = Movement.For(
                playersBody,
                playersAdjustedDestination);
            Body enemyBody = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Collision.WithAdjustedMovementTowardsTargetBody(
                    playersAdjustedMovement,
                    enemyBody);
            });
        }
    }

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

    [TestFixture]
    public class The_string_representation_of_a_collision
    {
        [Test]
        public void Contains_its_ID()
        {
            var collision = CreateCollision();
            StringAssert.Contains(
                collision.ID.ToString(),
                collision.ToString());
        }

        private static Collision CreateCollision()
        {
            var player = new Guid("db8956a2-2b44-40a8-ab9e-8e0e4f064220");
            var playersLocation = new UnityEngine.Vector3(3.0f, 0.0f, 0.0f);
            var playersBody = Body.ForEntityLocatedAt(
                player,
                playersLocation);
            var playersAdjustedDestination =
                new UnityEngine.Vector3(4.0f, 0.0f, 0.0f);
            var playersAdjustedMovement = Movement.For(
                playersBody,
                playersAdjustedDestination);
            var enemy = new Guid("0a35997f-1c46-426d-a9ee-dcbca907cae9");
            var enemysLocation = new UnityEngine.Vector3(5.0f, 0.0f, 0.0f);
            var enemysBody = Body.ForEntityLocatedAt(
                enemy,
                enemysLocation);
            return Collision.WithAdjustedMovementTowardsTargetBody(
                playersAdjustedMovement,
                enemysBody);
        }

        [Test]
        public void Contains_its_adjusted_movement()
        {
            var collision = CreateCollision();
            StringAssert.Contains(
                collision.AdjustedMovement.ToString(),
                collision.ToString());
        }

        [Test]
        public void Contains_its_target_body()
        {
            var collision = CreateCollision();
            StringAssert.Contains(
                collision.Target.ToString(),
                collision.ToString());
        }
    }
}
