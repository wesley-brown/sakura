using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sakura.Bodies.Core;
using Sakura.Bodies.Movements.Gateways;

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
            var bodies = new Dictionary<Guid, Body>();
            var movements = new Dictionary<Guid, Movement>();
            var gateway = Gateway.Of(
                bodies,
                movements);
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
    }
}
