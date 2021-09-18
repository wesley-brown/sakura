using System;
using NUnit.Framework;
using Sakura.Client;

namespace Collidable_Movement_System_Spec
{
    [TestFixture]
    public class Creating_a_collidable_movement_system_with_collidable_bodies_and_a_presenter
    {
        [Test]
        public void Does_not_support_a_null_collection_of_collidable_bodies()
        {
            CollidableBodies collidableBodies = null;
            CollidableMovementSystemPresenter presenter =
                new DummyCollidableMovementSystemPresenter();
            Assert.Throws<ArgumentNullException>(() =>
            {
                CollidableMovementSystem.WithCollidableBodiesAndPresenter(
                        collidableBodies,
                        presenter);
            });
        }
    }
}
