using System;
using NUnit.Framework;
using Sakura.Bodies.RegisterBody;

namespace Register_Body_System_Spec
{
    [TestFixture]
    public class Creating_with_registrations_and_a_presenter
    {
        [Test]
        public void Does_not_support_a_null_registrations()
        {
            Registrations registrations = null;
            var presenter = new DummyPresenter();
            Assert.Throws<ArgumentNullException>(() =>
            {
                Registration.Of(
                    registrations,
                    presenter);
            });
        }

        [Test]
        public void Does_not_support_a_null_presenter()
        {
            var registrations = new DummyRegistrations();
            Presenter presenter = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Registration.Of(
                    registrations,
                    presenter);
            });
        }
    }

    [TestFixture]
    public class Registering_a_body
    {
        [Test]
        public void For_an_entity_that_does_not_have_one_registers_that_body()
        {
            var registrations = new NoRegistrations();
            var presenter = new SpyPresenter();
            var system = Registration.Of(
                registrations,
                presenter);
            var entity = new Guid("db1395c6-6978-4e29-83bd-3088287acdc8");
            var bodyLocation = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);
            var input = new Input
            {
                Entity = entity,
                BodyLocation = bodyLocation
            };
            system.Register(input);
            Assert.AreEqual(
                0,
                presenter.InputErrors.Count);
            Assert.AreEqual(
                0,
                presenter.OutputErrors.Count);
            Assert.AreEqual(
                entity,
                presenter.Output.Entity);
            Assert.AreEqual(
                bodyLocation,
                presenter.Output.BodyLocation);
        }

        [Test]
        public void For_an_entity_that_does_have_one_is_an_input_error()
        {
            var registrations = new ExistingRegistrations();
            var presenter = new SpyPresenter();
            var system = Registration.Of(
                registrations,
                presenter);
            var entity = new Guid("db1395c6-6978-4e29-83bd-3088287acdc8");
            var bodyLocation = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);
            var input = new Input
            {
                Entity = entity,
                BodyLocation = bodyLocation
            };
            system.Register(input);
            Assert.AreEqual(
                1,
                presenter.InputErrors.Count);
            Assert.AreEqual(
                0,
                presenter.OutputErrors.Count);
            Assert.IsNull(presenter.Output);
        }

        [Test]
        public void And_encountering_errors_is_an_output_error()
        {
            var registrations = new DummyRegistrations();
            var presenter = new SpyPresenter();
            var system = Registration.Of(
                registrations,
                presenter);
            var entity = new Guid("db1395c6-6978-4e29-83bd-3088287acdc8");
            var bodyLocation = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);
            var input = new Input
            {
                Entity = entity,
                BodyLocation = bodyLocation
            };
            system.Register(input);
            Assert.AreEqual(
                0,
                presenter.InputErrors.Count);
            Assert.AreEqual(
                1,
                presenter.OutputErrors.Count);
            Assert.IsNull(presenter.Output);
        }
    }
}
