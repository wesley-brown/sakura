using System;
using NUnit.Framework;

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
    }
}
