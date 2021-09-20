using System;
using System.Collections;
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
    public class Moving_an_entity_towards_a_destination
    {
        [UnityTest]
        public IEnumerator When_it_has_no_body_is_an_error()
        {
            var noCollidableBodies = new NoCollidableBodies();
            var spyPresenter = new SpyPresenter();
            var system = CollidableMovementSystem
                .WithCollidableBodiesAndPresenter(
                    noCollidableBodies,
                    spyPresenter);
            var player = new Guid("8e7eaa84-f471-42ca-91ff-0eafe4cc5af3");
            var destination = new Vector3(3.0f, 0.0f, 3.0f);
            // Unity Test Framework currently does not support async tasks
            var task = system.MoveEntityTowardsDestination(
                player,
                destination);
            while (!task.IsCompleted)
                yield return null;
            Assert.IsTrue(spyPresenter.ReportedError);
        }
    }

    [TestFixture]
    public class Moving_an_entity_towards_a_destination_with_no_collisions
    {
        [UnityTest]
        public IEnumerator Moves_it_as_far_as_possible_in_one_tick()
        {
            var noCollisions = new NoCollisions();
            var spyPresenter = new SpyPresenter();
            var system = CollidableMovementSystem
                .WithCollidableBodiesAndPresenter(
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
            Assert.IsFalse(spyPresenter.ReportedError);
            Assert.AreEqual(
                destination,
                spyPresenter.EndingLocation);
        }
    }

    [TestFixture]
    public class Moving_an_entity_towards_a_destination_with_collisions
    {
        [UnityTest]
        public IEnumerator Moves_it_to_the_adjusted_collision_location_in_one_tick()
        {
            var alwaysCollisions = new AlwaysCollisions();
            var spyPresenter = new SpyPresenter();
            var system = CollidableMovementSystem
                .WithCollidableBodiesAndPresenter(
                    alwaysCollisions,
                    spyPresenter);
            var player = alwaysCollisions.Player;
            var destination = new Vector3(5.0f, 0.0f, 5.0f);
            var expectedEndingLocation =
                alwaysCollisions.AdjustedCollisionLocation;
            // Unity Test Framework currently does not support async tests
            var task = system.MoveEntityTowardsDestination(
                player,
                destination);
            while (!task.IsCompleted)
                yield return null;
            Assert.IsFalse(spyPresenter.ReportedError);
            Assert.AreEqual(
                expectedEndingLocation,
                spyPresenter.EndingLocation);
        }
    }
}
