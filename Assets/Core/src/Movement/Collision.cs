using System;
using System.Diagnostics;

namespace Sakura.Core
{
    /// <summary>
    ///     An instance of one <see cref="Body"/> trying to occupy the same
    ///     space as another after moving.
    /// </summary>
    public sealed class Collision
    {
        /// <summary>
        ///     Create a <see cref="Collision"/> with a given adjusted
        ///     <see cref="Movement"/> towards a given body.
        /// </summary>
        /// <param name="adjustedMovement">
        ///     The adjusted <see cref="Movement"/>.
        /// </param>
        /// <param name="body">
        ///     The <see cref="Body"/> the adjusted <see cref="Movement"/> is
        ///     towards.
        /// </param>
        /// <returns>
        ///     A <see cref="Collision"/> with the given adjusted
        ///     <see cref="Movement"/> towards the given <see cref="Body"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given adjusted <see cref="Movement"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given target <see cref="Body"/> is null.
        /// </exception>
        public static Collision WithAdjustedMovementTowardsTargetBody(
            Movement adjustedMovement,
            Body target)
        {
            if (adjustedMovement == null)
                throw new ArgumentNullException(nameof(adjustedMovement));
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            return new Collision(
                new Guid(),
                adjustedMovement,
                target);
        }

        /// <summary>
        ///     Create a <see cref="Collision"/> between two given
        ///     <see cref="Body"/>s.
        /// </summary>
        /// <param name="collider">
        ///     The <see cref="Body"/> that caused the collision by moving.
        /// </param>
        /// <param name="collidee">
        ///     The <see cref="Body"/> that was moved into.
        /// </param>
        /// <returns>
        ///     A <see cref="Collision"/> between the two given
        ///     <see cref="Body"/>s.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given collider <see cref="Body"/> is null.
        /// </exception>
        public static Collision BetweenBodies(
            Body collider,
            Body collidee)
        {
            if (collider == null)
                throw new ArgumentNullException(nameof(collider));
            throw new NotImplementedException();
        }

        private Collision(
            Guid id,
            Movement adjustedMovement,
            Body target)
        {
            this.id = id;
            Debug.Assert(adjustedMovement != null);
            this.adjustedMovement = adjustedMovement;
            Debug.Assert(target != null);
            this.target = target;
        }

        private readonly Guid id;
        private readonly Movement adjustedMovement;
        private readonly Body target;

        /// <summary>
        ///     The ID of this <see cref="Collision"/>.
        /// </summary>
        public Guid ID
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        ///     The adjusted <see cref="Movement"/> for the colliding body
        ///     after collisions are taken into account.
        /// </summary>
        public Movement AdjustedMovement
        {
            get
            {
                return adjustedMovement;
            }
        }

        /// <summary>
        ///     The target <see cref="Body"/> the adjusted
        ///     <see cref="Movement"/> is towards.
        /// </summary>
        public Body Target
        {
            get
            {
                return target;
            }
        }

        /// <summary>
        ///     Create a string representation of this
        ///     <see cref="Collision"/>.
        /// </summary>
        /// <returns>
        ///     A string representation of this <see cref="Collision"/>.
        /// </returns>
        public override string ToString()
        {
            return "{"
                + "ID="
                + ID
                + ", AdjustedMovement="
                + AdjustedMovement
                + ", Target="
                + Target
                + "}";
        }
    }
}
