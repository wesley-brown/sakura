using System;
using NUnit.Framework;
using Sakura.Client;

namespace Collidable_Movement_System_Spec
{
    [TestFixture]
    public class Creating_a_collidable_movement_system_with_a_speed_and_collidable_bodies_and_presenter
    {
        [Test]
        public void Does_not_support_a_negative_speed()
        {
            var speed = -5.0f;
            var collidableBodies = new DummyCollidableBodies();
            CollidableMovementSystemPresenter presenter =
                new DummyCollidableMovementSystemPresenter();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                CollidableMovementSystem
                    .WithSpeedAndCollidableBodiesAndPresenter(
                        speed,
                        collidableBodies,
                        presenter);
            });
        }

        [Test]
        public void Does_not_support_a_null_collection_of_collidable_bodies()
        {
            var speed = 5.0f;
            CollidableBodies collidableBodies = null;
            CollidableMovementSystemPresenter presenter =
                new DummyCollidableMovementSystemPresenter();
            Assert.Throws<ArgumentNullException>(() =>
            {
                CollidableMovementSystem
                    .WithSpeedAndCollidableBodiesAndPresenter(
                        speed,
                        collidableBodies,
                        presenter);
            });
        }
    }
}
