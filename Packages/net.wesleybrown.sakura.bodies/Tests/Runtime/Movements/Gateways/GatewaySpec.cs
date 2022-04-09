using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sakura.Bodies.Core;
using Sakura.Bodies.Movements.Gateways;
using UnityEngine;

namespace Movement_Gateway_Spec
{
    [TestFixture]
    public class Creating
    {
        [Test]
        public void With_A_Null_Dictionary_Of_Bodies_Is_Not_Supported()
        {
            IDictionary<Guid, Body> bodies = null;
            var movements = new Dictionary<Guid, Movement>();
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gateway.Of(
                    bodies,
                    movements);
            });
        }

        [Test]
        public void With_A_Null_Dictionary_Of_Movements_Is_Not_Supported()
        {
            var bodies = new Dictionary<Guid, Body>();
            IDictionary<Guid, Movement> movements = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gateway.Of(
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
            Movement movement = null;
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

        private static Gateway CreateEmptyGateway()
        {
            var bodies = new Dictionary<Guid, Body>();
            var movements = new Dictionary<Guid, Movement>();
            return Gateway.Of(
                bodies,
                movements);
        }

        [Test]
        public void Returns_That_Movement()
        {
            var gateway = CreateEmptyGateway();
            var destination = new Vector3(1.0f, 0.0f, 1.0f);
            var movementSpeed = 1.0f;
            var movement = Movement.TowardsDestinationWithSpeed(
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
            var bodies = new Dictionary<Guid, Body>();
            var movements = new Dictionary<Guid, Movement>();
            var gateway = Gateway.Of(
                bodies,
                movements);
            var destination = new Vector3(3.1f, -0.54f, 123.87f);
            var movementSpeed = 10.5f;
            var movement = Movement.TowardsDestinationWithSpeed(
                destination,
                movementSpeed);
            var timestamp = 1000000.1233456f;
            var entity = new Guid("291512c2-e7b0-43f2-aa69-d6d93bf2534d");
            gateway.Add(
                movement,
                timestamp,
                entity);
            var expectedEntry = new KeyValuePair<Guid, Movement>(
                entity,
                movement);
            CollectionAssert.Contains(
                movements,
                expectedEntry);
        }
    }
}
