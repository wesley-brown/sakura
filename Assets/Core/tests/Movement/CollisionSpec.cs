using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Collision_Spec
{
    [TestFixture]
    public class Creating_a_collision_with_an_adjusted_movement_towards_a_body
    {
        [Test]
        public void Does_not_support_a_null_movement()
        {
            Movement movement = null;
            var entity = new Guid("0a35997f-1c46-426d-a9ee-dcbca907cae9");
            var location = new Vector3(5.0f, 0.0f, 0.0f);
            var body = BodyTemp.ForEntityLocatedAt(
                entity,
                location);
            Assert.Throws<ArgumentNullException>(() =>
            {
                Sakura.Core.Collision.WithAdjustedMovementTowardsBody(
                    movement,
                    body);
            });
        }

        [Test]
        public void Does_not_support_a_null_body()
        {
            var player = new Guid("db8956a2-2b44-40a8-ab9e-8e0e4f064220");
            var playersLocation = new Vector3(3.0f, 0.0f, 0.0f);
            var playersBody = BodyTemp.ForEntityLocatedAt(
                player,
                playersLocation);
            var playersAdjustedDestination = new Vector3(4.0f, 0.0f, 0.0f);
            var playersAdjustedMovement = Movement.For(
                playersBody,
                playersAdjustedDestination);
            BodyTemp enemyBody = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Sakura.Core.Collision.WithAdjustedMovementTowardsBody(
                    playersAdjustedMovement,
                    enemyBody);
            });
        }
    }

    [TestFixture]
    public class The_string_representation_of_a_collision
    {
        [Test]
        public void Contains_its_adjusted_movement()
        {
            var player = new Guid("db8956a2-2b44-40a8-ab9e-8e0e4f064220");
            var playersLocation = new Vector3(3.0f, 0.0f, 0.0f);
            var playersBody = BodyTemp.ForEntityLocatedAt(
                player,
                playersLocation);
            var playersAdjustedDestination = new Vector3(4.0f, 0.0f, 0.0f);
            var playersAdjustedMovement = Movement.For(
                playersBody,
                playersAdjustedDestination);

            var enemy = new Guid("0a35997f-1c46-426d-a9ee-dcbca907cae9");
            var enemysLocation = new Vector3(5.0f, 0.0f, 0.0f);
            var enemysBody = BodyTemp.ForEntityLocatedAt(
                enemy,
                enemysLocation);

            var collision = Sakura.Core.Collision.WithAdjustedMovementTowardsBody(
                playersAdjustedMovement,
                enemysBody);
            StringAssert.Contains(
                collision.AdjustedMovement.ToString(),
                collision.ToString());
        }
    }
}
