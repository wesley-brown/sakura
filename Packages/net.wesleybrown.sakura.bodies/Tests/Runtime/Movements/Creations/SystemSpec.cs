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
                presenter.ValidationErrors.Count);
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
                presenter.ValidationErrors.Count);
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
                presenter.ValidationErrors.Count);
            Assert.AreEqual(
                0,
                presenter.ProcessingErrors.Count);
        }

        [Test]
        [TestCase(-0.000000001f)]
        [TestCase(-100.0f)]
        [TestCase(float.MinValue)]
        public void Based_On_A_Negative_Speed_Is_A_Validation_Error(float speed)
        {
            var gateway = new Gateways.Dummy();
            var presenter = new Presenters.Spy();
            var fixedTimeStepSeconds = 7184.1816f;
            var system = Sakura.Bodies.Movements.Creations.System.Of(
                gateway,
                presenter,
                fixedTimeStepSeconds);
            var input = new Input
            {
                Entity = "550d48a2-13fc-4f85-99ae-9ceccac1ec90",
                Destination = new UnityEngine.Vector3(-1.0f, 5.4f, 1.2345f),
                SpeedMetersPerSecond = speed,
                Timestamp = 987654321.012345f
            };
            system.Move(input);
            Assert.IsNull(presenter.Output);
            Assert.AreEqual(
                1,
                presenter.ValidationErrors.Count);
            Assert.AreEqual(
                0,
                presenter.ProcessingErrors.Count);

        }

        [Test]
        [TestCase(-1.0f)]
        [TestCase(-456.789f)]
        [TestCase(float.MinValue)]
        public void Based_On_A_Negative_Timestamp_Is_A_Validation_Error(
            float timestamp)
        {
            var gateway = new Gateways.Dummy();
            var presenter = new Presenters.Spy();
            var fixedTimeStepSeconds = 0.3333333333f;
            var system = Sakura.Bodies.Movements.Creations.System.Of(
                gateway,
                presenter,
                fixedTimeStepSeconds);
            var input = new Input
            {
                Entity = "9c76984b-2c6b-486b-8477-980c294c185d",
                Destination = new UnityEngine.Vector3(1.0f, -5.0f, 0.123f),
                SpeedMetersPerSecond = 1.0f,
                Timestamp = timestamp
            };
            system.Move(input);
            Assert.IsNull(presenter.Output);
            Assert.AreEqual(
                1,
                presenter.ValidationErrors.Count);
            Assert.AreEqual(
                0,
                presenter.ProcessingErrors.Count);
        }

        [Test]
        public void For_An_Entity_That_Does_Have_A_Body_Is_A_Processing_Error()
        {
            var gateway = new Gateways.NoBodies();
            var presenter = new Presenters.Spy();
            var fixedTimeStepSeconds = 0.2f;
            var system = Sakura.Bodies.Movements.Creations.System.Of(
                gateway,
                presenter,
                fixedTimeStepSeconds);
            var input = new Input
            {
                Entity = "491288cb-969b-4cf3-a9ea-472e2bd3fdbe",
                Destination = UnityEngine.Vector3.zero,
                SpeedMetersPerSecond = 0.0f,
                Timestamp = 0.5f
            };
            system.Move(input);
            Assert.IsNull(presenter.Output);
            Assert.AreEqual(
                0,
                presenter.ValidationErrors.Count);
            Assert.AreEqual(
                1,
                presenter.ProcessingErrors.Count);
        }
    }
}
