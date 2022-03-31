using System;
using NUnit.Framework;
using Sakura.Bodies.Movements.Creations;

namespace Movement_Creation_System_Spec
{
    [TestFixture]
    public class Creating
    {
        [Test]
        [TestCase(-0.02f)]
        [TestCase(-123.45f)]
        [TestCase(float.MinValue)]
        public void With_A_Negative_Time_Step_Is_Not_Supported(
            float fixedTimeStepSeconds)
        {
            var gateway = new Gateways.Dummy();
            var presenter = new Presenters.Dummy();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Sakura.Bodies.Movements.Creations.System.Of(
                    gateway,
                    presenter,
                    fixedTimeStepSeconds);
            });
        }

        [Test]
        public void With_A_Time_Step_Of_0_Is_Not_Supported()
        {
            var gateway = new Gateways.Dummy();
            var presenter = new Presenters.Dummy();
            var fixedTimeStepSeconds = 0f;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Sakura.Bodies.Movements.Creations.System.Of(
                    gateway,
                    presenter,
                    fixedTimeStepSeconds);
            });
        }

        [Test]
        public void With_A_Null_Gateway_Is_Not_Supported()
        {
            Gateway gateway = null;
            var presenter = new Presenters.Dummy();
            var fixedTimeStepSeconds = 1.0f;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Sakura.Bodies.Movements.Creations.System.Of(
                    gateway,
                    presenter,
                    fixedTimeStepSeconds);
            });
        }

        [Test]
        public void With_A_Null_Presenter_Is_Not_Supported()
        {
            var gateway = new Gateways.Dummy();
            OutputPort presenter = null;
            var fixedTimeStepSeconds = 0.5f;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Sakura.Bodies.Movements.Creations.System.Of(
                    gateway,
                    presenter,
                    fixedTimeStepSeconds);
            });
        }
    }
}
