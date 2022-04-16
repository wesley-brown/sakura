using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Movement_Gateway_Spec
{
    [TestFixture]
    public class Creating
    {
        [Test]
        public void With_A_Null_Dictionary_Of_Bodies_Is_Not_Supported()
        {
            IDictionary<Guid, Sakura.Bodies.Core.Body> bodies = null;
            var movements = new Dictionary<Guid, Sakura.Bodies.Movements.Gateways.Movement>();
            Assert.Throws<ArgumentNullException>(() =>
            {
                Sakura.Bodies.Movements.Gateways.Gateway.Of(
                    bodies,
                    movements);
            });
        }

        [Test]
        public void With_A_Null_Dictionary_Of_Movements_Is_Not_Supported()
        {
            var bodies = new Dictionary<Guid, Sakura.Bodies.Core.Body>();
            IDictionary<Guid, Sakura.Bodies.Movements.Gateways.Movement> movements = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Sakura.Bodies.Movements.Gateways.Gateway.Of(
                    bodies,
                    movements);
            });
        }
    }

    [TestFixture]
    public class Adding_A_Movement
    {
        [Test]
        public void Does_Not_Support_A_Null_Movement()
        {
            var gateway = CreateEmptyGateway();
            Sakura.Bodies.Core.Movement movement = null;
            var timestamp = 0f;
            var entity = new Guid("6475ca49-e034-45f4-8a89-873bba7f93f1");
            Assert.Throws<ArgumentNullException>(() =>
            {
                gateway.Add(
                    movement,
                    timestamp,
                    entity);
            });
        }

        private static Sakura.Bodies.Movements.Creations.Gateway CreateEmptyGateway()
        {
            var bodies = new Dictionary<Guid, Sakura.Bodies.Core.Body>();
            var movements = new Dictionary<Guid, Sakura.Bodies.Movements.Gateways.Movement>();
            return Sakura.Bodies.Movements.Gateways.Gateway.Of(
                bodies,
                movements);
        }

        [Test]
        public void Returns_That_Movement()
        {
            var gateway = CreateEmptyGateway();
            var destination = new Vector3(1.0f, 0.0f, 1.0f);
            var movementSpeed = 1.0f;
            var movement = Sakura.Bodies.Core.Movement.TowardsDestinationWithSpeed(
                destination,
                movementSpeed);
            var timestamp = 0f;
            var entity = new Guid("442789aa-94ac-4565-b62a-fe19ea526e87");
            var addedMovement = gateway.Add(
                movement,
                timestamp,
                entity);
            Assert.AreEqual(
                movement,
                addedMovement);
        }

        [Test]
        public void For_An_Entity_That_Does_Not_Have_One_Adds_That_Movement_To_The_Dictionary()
        {
            var bodies = new Dictionary<Guid, Sakura.Bodies.Core.Body>();
            var movements = new Dictionary<Guid, Sakura.Bodies.Movements.Gateways.Movement>();
            var gateway = Sakura.Bodies.Movements.Gateways.Gateway.Of(
                bodies,
                movements);
            var destination = new Vector3(3.1f, -0.54f, 123.87f);
            var movementSpeed = 10.5f;
            var movement = Sakura.Bodies.Core.Movement.TowardsDestinationWithSpeed(
                destination,
                movementSpeed);
            var timestamp = 1000000.1233456f;
            var entity = new Guid("291512c2-e7b0-43f2-aa69-d6d93bf2534d");
            gateway.Add(
                movement,
                timestamp,
                entity);
            var expectedMovement = new Sakura.Bodies.Movements.Gateways.Movement
            {
                Destination = destination,
                MovementSpeed = movementSpeed
            };
            var expectedEntry = new KeyValuePair<Guid, Sakura.Bodies.Movements.Gateways.Movement>(
                entity,
                expectedMovement);
            CollectionAssert.Contains(
                movements,
                expectedEntry);
        }

        [Test]
        public void For_An_Entity_That_Has_One_Does_Not_Add_That_Movement_To_The_Dictionary()
        {
            var entity = new Guid("543e5263-4670-4092-b814-5d2f72e03860");
            var existingDestination = new Vector3(-0.1f, 12.45f, 0f);
            var existingMovementSpeed = 10.5f;
            var existingMovement = new Sakura.Bodies.Movements.Gateways.Movement
            {
                Destination = existingDestination,
                MovementSpeed = existingMovementSpeed
            };
            var bodies = new Dictionary<Guid, Sakura.Bodies.Core.Body>();
            var movements = new Dictionary<Guid, Sakura.Bodies.Movements.Gateways.Movement>
            {
                { entity, existingMovement }
            };
            var gateway = Sakura.Bodies.Movements.Gateways.Gateway.Of(
                bodies,
                movements);
            var destination = new Vector3(2.0f, 0.5f, -9f);
            var movementSpeed = 8.4f;
            var movement = Sakura.Bodies.Core.Movement.TowardsDestinationWithSpeed(
                destination,
                movementSpeed);
            var timestamp = 0.16f;
            gateway.Add(
                movement,
                timestamp,
                entity);
            var expectedEntry = new KeyValuePair<Guid, Sakura.Bodies.Movements.Gateways.Movement>(
                entity,
                existingMovement);
            CollectionAssert.Contains(
                movements,
                expectedEntry);
        }
    }

    [TestFixture]
    public class Retrieving_The_Body
    {
        [Test]
        public void For_An_Entity_That_Does_Not_Have_One_Returns_Null()
        {
            var bodies = new Dictionary<Guid, Sakura.Bodies.Core.Body>();
            var movements = new Dictionary<Guid, Sakura.Bodies.Movements.Gateways.Movement>();
            var gateway = Sakura.Bodies.Movements.Gateways.Gateway.Of(
                bodies,
                movements);
            var entity = new Guid("73903060-f4c7-4e47-953d-e73c83a8bcdd");
            var body = gateway.BodyFor(entity);
            Assert.IsNull(body);
        }

        [Test]
        public void For_An_Entity_That_Has_One_Returns_That_Body()
        {
            var entity = new Guid("54d0732e-f54e-4c7a-ba3b-b43a601149c5");
            var location = new Vector3(1.0f, 0.0f, 0.0f);
            var existingBody = Sakura.Bodies.Core.Body.ForEntityLocatedAt(
                entity,
                location);
            var bodies = new Dictionary<Guid, Sakura.Bodies.Core.Body>
            {
                { entity, existingBody }
            };
            var movements = new Dictionary<Guid, Sakura.Bodies.Movements.Gateways.Movement>();
            var gateway = Sakura.Bodies.Movements.Gateways.Gateway.Of(
                bodies,
                movements);
            var body = gateway.BodyFor(entity);
            Assert.AreEqual(
                existingBody,
                body);
        }
    }
}
