using System;
using NUnit.Framework;
using Sakura.Core;
using UnityEngine;

namespace Collision_Temp_Spec
{
    [TestFixture]
    public class Creating_a_collision_with_an_adjusted_movement_towards_a_body
    {
        [Test]
        public void Does_not_support_a_null_movement()
        {
            MovementTemp movement = null;
            var entity = new Guid("0a35997f-1c46-426d-a9ee-dcbca907cae9");
            var location = new Vector3(5.0f, 0.0f, 0.0f);
            var body = BodyTemp.ForEntityLocatedAt(
                entity,
                location);
            Assert.Throws<ArgumentNullException>(() =>
            {
                CollisionTemp.WithAdjustedMovementTowardsBody(
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
            var playersAdjustedMovement = MovementTemp.For(
                playersBody,
                playersAdjustedDestination);
            BodyTemp enemyBody = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                CollisionTemp.WithAdjustedMovementTowardsBody(
                    playersAdjustedMovement,
                    enemyBody);
            });
        }
    }
}
