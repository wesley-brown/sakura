using System;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using Sakura.Client;
using UnityEngine;
using UnityEngine.TestTools;

namespace Collidable_Movement_System_Spec
{
    [TestFixture]
    public class Creating_a_collidable_movement_system_with_collidable_bodies_and_a_presenter
    {
        [Test]
        public void Does_not_support_a_null_collection_of_collidable_bodies()
        {
            CollidableBodies collidableBodies = null;
            var presenter = new DummyCollidableMovementSystemPresenter();
            Assert.Throws<ArgumentNullException>(() =>
            {
                CollidableMovementSystem.WithCollidableBodiesAndPresenter(
                        collidableBodies,
                        presenter);
            });
        }

        [Test]
        public void Does_not_support_a_null_presenter()
        {
            var collidableBodies = new DummyCollidableBodies();
            CollidableMovementSystemPresenter presenter = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                CollidableMovementSystem.WithCollidableBodiesAndPresenter(
                    collidableBodies,
                    presenter);
            });
        }
    }

    [TestFixture]
    public class Moving_a_body_towards_a_destination_with_no_collisions
    {
        [UnityTest]
        public IEnumerator Moves_that_body_as_far_as_possible_in_a_single_tick()
        {
            var noCollisions = new NoCollisions();
            var spyPresenter = new SpyPresenter();
            var system =
                CollidableMovementSystem.WithCollidableBodiesAndPresenter(
                    noCollisions,
                    spyPresenter);
            var player = noCollisions.Player;
            var destination = new Vector3(2.0f, 0.0f, 2.0f);
            // Unity Test Framework currently does not support async tests
            var task = system.MoveEntityTowardsDestination(
                player,
                destination);
            while (!task.IsCompleted)
                yield return null;
            Assert.AreEqual(
                destination,
                spyPresenter.EndingLocation);
        }
    }
}
