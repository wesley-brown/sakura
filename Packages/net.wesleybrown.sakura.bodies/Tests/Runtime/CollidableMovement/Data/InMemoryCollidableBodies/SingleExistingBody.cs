using System;
using Sakura.Core;
using Sakura.Bodies.CollidableMovement.Data;

namespace In_Memory_Collidable_Bodies_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Bodies"/> that only ever has a
    ///     single <see cref="Body"/> that changes after a call to
    ///     <see cref="AddBody(Body)"/>.
    /// </summary>
    sealed class SingleExistingBody : Bodies
    {
        static SingleExistingBody()
        {
            var entity = new Guid("86c8aea8-7644-45cf-b2e4-aa3c84437129");
            var initialLocation = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);
            initialBody = Body.ForEntityLocatedAt(
                entity,
                initialLocation);

            var changedLocation = new UnityEngine.Vector3(5.0f, 0.0f, 5.0f);
            changedBody = initialBody.TeleportTo(changedLocation);
        }

        private static readonly Body initialBody;
        private static readonly Body changedBody;

        /// <summary>
        ///     The <see cref="Body"/> that this
        ///     <see cref="SingleExistingBody"/> has before a call to
        ///     <see cref="AddBody(Body)"/>.
        /// </summary>
        internal static Body InitialBody
        {
            get
            {
                return initialBody;
            }
        }

        /// <summary>
        ///     The <see cref="Body"/> that this
        ///     <see cref="SingleExistingBody"/> has after a call to
        ///     <see cref="AddBody(Body)"/>.
        /// </summary>
        internal static Body ChangedBody
        {
            get
            {
                return changedBody;
            }
        }

        /// <summary>
        ///     Create a new <see cref="SingleExistingBody"/>.
        /// </summary>
        internal SingleExistingBody()
        {
            body = InitialBody;
        }

        private Body body;

        /// <summary>
        ///     Add a given <see cref="Body"/> to this <see cref="Bodies"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/> to add.
        /// </param>
        public void AddBody(Body body)
        {
            this.body = ChangedBody;
        }

        /// <summary>
        ///     The <see cref="Body"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     <see cref="InitialBody"/> before a call to
        ///     <see cref="AddBody(Body)"/>; <see cref="ChangedBody"/> after a
        ///     call to <see cref="AddBody(Body)"/>.
        /// </returns>
        public Body BodyForEntity(Guid entity)
        {
            return body;
        }
    }
}
