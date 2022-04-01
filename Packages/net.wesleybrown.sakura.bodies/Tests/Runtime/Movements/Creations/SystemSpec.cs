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

    [TestFixture]
    public class Creating_A_Movement
    {
        [Test]
        public void Based_On_A_Null_Input_Is_A_Validation_Error()
        {
            var gateway = new Gateways.Dummy();
            var presenter = new Presenters.Spy();
            var fixedTimeStepSeconds = 2.3f;
            var system = Sakura.Bodies.Movements.Creations.System.Of(
                gateway,
                presenter,
                fixedTimeStepSeconds);
            Input input = null;
            system.Move(input);
            Assert.IsNull(presenter.Output);
            Assert.AreEqual(
                1,
                presenter.ValidaitonErrors.Count);
            Assert.AreEqual(
                0,
                presenter.ProcessingErrors.Count);
        }

        [Test]
        public void Based_On_A_Null_Entity_Is_A_Validation_Error()
        {
            var gateway = new Gateways.Dummy();
            var presenter = new Presenters.Spy();
            var fixedTimeStepSeconds = 4.7f;
            var system = Sakura.Bodies.Movements.Creations.System.Of(
                gateway,
                presenter,
                fixedTimeStepSeconds);
            var input = new Input
            {
                Entity = null,
                Destination = UnityEngine.Vector3.zero,
                SpeedMetersPerSecond = 0f,
                Timestamp = 0f
            };
            system.Move(input);
            Assert.IsNull(presenter.Output);
            Assert.AreEqual(
                1,
                presenter.ValidaitonErrors.Count);
            Assert.AreEqual(
                0,
                presenter.ProcessingErrors.Count);
        }

        [Test]
        public void Based_On_An_Entity_That_Is_Not_A_Guid_Is_A_Validation_Error()
        {
            var gateway = new Gateways.Dummy();
            var presenter = new Presenters.Spy();
            var fixedTimeStepSeconds = 123.456f;
            var system = Sakura.Bodies.Movements.Creations.System.Of(
                gateway,
                presenter,
                fixedTimeStepSeconds);
            var input = new Input
            {
                Entity = "not a guid",
                Destination = new UnityEngine.Vector3(1.0f, 2.0f, 3.0f),
                SpeedMetersPerSecond = 5.0f,
                Timestamp = 1234.56f
            };
            system.Move(input);
            Assert.IsNull(presenter.Output);
            Assert.AreEqual(
                1,
                presenter.ValidaitonErrors.Count);
            Assert.AreEqual(
                0,
                presenter.ProcessingErrors.Count);
        }
    }
}
