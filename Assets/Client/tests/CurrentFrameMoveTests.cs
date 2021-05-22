using System;
using NUnit.Framework;
using Sakura.Collisions;
using Sakura.Movements;
using Sakura.Movements.Responses;

namespace Current_frame_move_spec
{
    [TestFixture]
    public class A_current_frame_move
    {
        [Test]
        public void Throws_when_created_without_movements()
        {
            var ID = new Guid("a6a398e9-b7f0-4ccf-be02-e7bf4cdcb7a4");
            var allCollisions = new AlwaysColliding();
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CurrentFrameMove(
                    ID,
                    null,
                    allCollisions);
            });
        }

        [Test]
        public void Throws_when_created_without_collisions()
        {
            var ID = new Guid("a6a398e9-b7f0-4ccf-be02-e7bf4cdcb7a4");
            var allMovements = new AlwaysMoving();
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CurrentFrameMove(
                    ID,
                    allMovements,
                    null);
            });
        }
    }

    [TestFixture]
    public class An_entity_with_the_nil_UUID
    {
        [Test]
        public void Cannot_be_moved()
        {
            var ID = Guid.Empty;
            var allMovements = new AlwaysMoving();
            var allCollisions = new AlwaysColliding();
            var move = new CurrentFrameMove(
                ID,
                allMovements,
                allCollisions);
            var response = move.Response();
            AssertCannotBeMoved(response);
        }

        private void AssertCannotBeMoved(MoveResponse response)
        {
            Assert.IsFalse(response.DidMove);
            Assert.IsNull(response.NewLocation);
            Assert.IsNotNull(response.Errors);
            Assert.IsTrue(response.Errors.Count > 0);
        }
    }

    [TestFixture]
    public class An_entity_with_no_movement_during_the_current_frame
    {
        [Test]
        public void Will_not_be_moved()
        {
            var ID = new Guid("134c6e9f-5a0b-43d5-b5bc-7d8c7501c614");
            var allMovements = new NeverMoving();
            var allCollisions = new AlwaysColliding();
            var move = new CurrentFrameMove(
                ID,
                allMovements,
                allCollisions);
            var response = move.Response();
            AssertWillNotBeMoved(response);
        }

        private void AssertWillNotBeMoved(MoveResponse response)
        {
            Assert.IsFalse(response.DidMove);
            Assert.IsNull(response.NewLocation);
            Assert.IsNotNull(response.Errors);
            Assert.IsTrue(response.Errors.Count == 0);
        }
    }
}
