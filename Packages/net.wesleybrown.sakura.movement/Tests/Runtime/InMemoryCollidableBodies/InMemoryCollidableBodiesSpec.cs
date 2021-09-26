using System;
using NUnit.Framework;
using Sakura.Core;
using Sakura.Data;

namespace In_Memory_Collidable_Bodies_Spec
{
    [TestFixture]
    public class Creating_with_collections
    {
        [Test]
        public void Does_not_support_a_null_collection_of_movement_speeds()
        {
            MovementSpeeds movementSpeeds = null;
            var bodies = new DummyBodies();
            var collisions = new DummyCollisions();
            Assert.Throws<ArgumentNullException>(() =>
            {
                InMemoryCollidableBodies.WithCollections(
                    movementSpeeds,
                    bodies,
                    collisions);
            });
        }

        [Test]
        public void Does_not_support_a_null_collection_of_bodies()
        {
            var movementSpeeds = new DummyMovementSpeeds();
            Bodies bodies = null;
            var collisions = new DummyCollisions();
            Assert.Throws<ArgumentNullException>(() =>
            {
                InMemoryCollidableBodies.WithCollections(
                    movementSpeeds,
                    bodies,
                    collisions);
            });
        }

        [Test]
        public void Does_not_support_a_null_collection_of_collisions()
        {
            var movementSpeeds = new DummyMovementSpeeds();
            var bodies = new DummyBodies();
            Collisions collisions = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                InMemoryCollidableBodies.WithCollections(
                    movementSpeeds,
                    bodies,
                    collisions);
            });
        }
    }

    [TestFixture]
    public class The_movement_speed_for_an_entity
    {
        [Test]
        public void That_does_not_have_one_is_zero()
        {
            var movementSpeeds = new NoMovementSpeeds();
            var bodies = new DummyBodies();
            var collisions = new DummyCollisions();
            var collidableBodies = InMemoryCollidableBodies.WithCollections(
                movementSpeeds,
                bodies,
                collisions);
            var entity = new Guid("9c7aba92-ec3d-4862-a16f-c98214cd4a19");
            var movementSpeed =
                collidableBodies.MovementSpeedForEntity(entity);
            Assert.AreEqual(
                0.0f,
                movementSpeed);
        }

        [Test]
        public void That_does_have_one_is_its_movement_speed()
        {
            var movementSpeeds = new SameMovementSpeeds();
            var bodies = new DummyBodies();
            var collisions = new DummyCollisions();
            var collidableBodies = InMemoryCollidableBodies.WithCollections(
                movementSpeeds,
                bodies,
                collisions);
            var entity = new Guid("9c7aba92-ec3d-4862-a16f-c98214cd4a19");
            var movementSpeed =
                collidableBodies.MovementSpeedForEntity(entity);
            Assert.AreEqual(
                SameMovementSpeeds.MovementSpeed,
                movementSpeed);
        }
    }

    [TestFixture]
    public class Replacing_the_body_for_an_entity
    {
        [Test]
        public void Does_not_support_a_null_body()
        {
            var collidableBodies = CreateCollidableBodies();
            var entity = SingleExistingBody.InitialBody.Entity;
            Body body = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                collidableBodies.ReplaceEntityBody(
                    entity,
                    body);
            });
        }

        private static InMemoryCollidableBodies CreateCollidableBodies()
        {
            var movementSpeeds = new DummyMovementSpeeds();
            var bodies = new SingleExistingBody();
            var collisions = new DummyCollisions();
            return InMemoryCollidableBodies.WithCollections(
                movementSpeeds,
                bodies,
                collisions);
        }

        [Test]
        public void Makes_that_body_the_body_for_that_entity()
        {
            var collidableBodies = CreateCollidableBodies();
            var entity = SingleExistingBody.InitialBody.Entity;
            Assert.AreEqual(
                SingleExistingBody.InitialBody.Entity,
                collidableBodies.BodyForEntity(entity).Entity);
            Assert.AreEqual(
                SingleExistingBody.InitialBody.Location,
                collidableBodies.BodyForEntity(entity).Location);
            var newBody = SingleExistingBody.ChangedBody;
            collidableBodies.ReplaceEntityBody(
                entity,
                newBody);
            Assert.AreEqual(
                newBody.Entity,
                collidableBodies.BodyForEntity(entity).Entity);
            Assert.AreEqual(
                newBody.Location,
                collidableBodies.BodyForEntity(entity).Location);
        }
    }
}
