using System;
using Sakura.Bodies.CollidableMovement;
using Sakura.Bodies.Core;

namespace Collidable_Movement_System_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="CollidableBodies"/> that has
    ///     no <see cref="Collision"/>s.
    /// </summary>
    sealed class NoCollisions : CollidableBodies
    {
        /// <summary>
        ///     Create a new <see cref="NoCollisions"/>.
        /// </summary>
        internal NoCollisions()
        {
            var player = new Guid("0c6cace6-95c3-4c0c-a608-3918818a4a03");
            var playersLocation = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);
            playersBody = Body.ForEntityLocatedAt(
                player,
                playersLocation);
        }

        private readonly Body playersBody;

        /// <summary>
        ///     The single entity that this <see cref="NoCollisions"/> has.
        /// </summary>
        internal Guid Player
        {
            get
            {
                return playersBody.Entity;
            }
        }

        /// <summary>
        ///     The <see cref="Body"/> for <see cref="Player"/>.
        /// </summary>
        internal Body PlayersBody
        {
            get
            {
                return playersBody;
            }
        }

        /// <summary>
        ///     The movement speed for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Always returns 5.0f.
        /// </returns>
        public float MovementSpeedForEntity(Guid entity)
        {
            return 5.0f;
        }

        /// <summary>
        ///     The <see cref="Body"/> for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Always returns <see cref="PlayersBody"/>.
        /// </returns>
        public Body BodyForEntity(Guid entity)
        {
            return playersBody;
        }

        /// <summary>
        ///    Replace the <see cref="Body"/> that currently represents a
        ///    given entity with a given <see cref="Body"/>.
        /// </summary>
        /// <param name="entity">
        ///     The entity to replace the <see cref="Body"/> of.
        /// </param>
        /// <param name="body">
        ///     The <see cref="Body"/> to replace the given entity's
        ///     <see cref="Body"/> with.
        /// </param>
        public void ReplaceEntityBody(
            Guid entity,
            Body body)
        {
            // No-op
        }

        /// <summary>
        ///     Whether or not a given <see cref="Body"/> is currently
        ///     colliding with another <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/> to check for <see cref="Collision"/>s
        ///     for.
        /// </param>
        /// <returns>
        ///     Always returns false.
        /// </returns>
        public bool BodyIsColliding(Body body)
        {
            return false;
        }

        /// <summary>
        ///     The <see cref="Collision"/> caused by the movement of a given
        ///     <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     The task result will always be null.
        /// </returns>
        public Collision CollisionForBody(Body body)
        {
            return null;
        }

        /// <summary>
        ///     The <see cref="Collision"/>, if any, caused by applying a given
        ///     <see cref="Movement"/> to a given <see cref="Body"/>.
        /// </summary>
        /// <param name="movement">
        ///     The <see cref="Movement"/> to apply to the <see cref="Body"/>.
        /// </param>
        /// <param name="body">
        ///     The <see cref="Body"/> to apply the <see cref="Movement"/> to.
        /// </param>
        /// <returns>
        ///     Always returns null.
        /// </returns>
        public Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body)
        {
            return null;
        }
    }
}
