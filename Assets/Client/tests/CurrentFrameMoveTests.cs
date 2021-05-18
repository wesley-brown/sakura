using System;
using NUnit.Framework;
using Sakura.Client;

namespace Current_frame_move_spec
{
    [TestFixture]
    public class A_current_frame_move
    {
        [Test]
        public void Throws_when_created_without_movements()
        {
            var allCollisions = new AlwaysColliding();
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CurrentFrameMove(
                    null,
                    allCollisions);
            });
        }

        [Test]
        public void Throws_when_created_without_collisions()
        {
            var allMovements = new AlwaysMoving();
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CurrentFrameMove(
                    allMovements,
                    null);
            });
        }
    }
}
