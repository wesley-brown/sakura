using System;
using Sakura.Bodies.RegisterBody;
using NUnit.Framework;

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
    }
}
