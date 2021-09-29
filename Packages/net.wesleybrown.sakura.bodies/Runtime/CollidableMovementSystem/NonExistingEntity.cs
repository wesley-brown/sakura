using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Sakura.Bodies.CollidableMovement
{
    /// <summary>
    ///     The <see cref="Exception"/> that is thrown when an entity does not
    ///     exist.
    /// </summary>
    [Serializable]
    sealed class NonExistingEntity : Exception
    {
        /// <summary>
        ///     Create a new <see cref="NonExistingEntity"/>.
        /// </summary>
        internal NonExistingEntity()
        {
        }

        /// <summary>
        ///     Create a new <see cref="NonExistingEntity"/> with a given
        ///     error message.
        /// </summary>
        /// <param name="message">
        ///     The error message.
        /// </param>
        internal NonExistingEntity(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Create a new <see cref="NonExistingEntity"/> with a given
        ///     error message and inner <see cref="Exception"/>.
        /// </summary>
        /// <param name="message">
        ///     The error message.
        /// </param>
        /// <param name="inner">
        ///     The inner <see cref="Exception"/>.
        /// </param>
        internal NonExistingEntity(
            string message,
            Exception inner)
        :
            base(
                message,
                inner)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private NonExistingEntity(
            SerializationInfo info,
            StreamingContext context)
        :
            base(
                info,
                context)
        {
            entity = (Guid)info.GetValue("Entity", typeof(Guid));
        }

        /// <summary>
        ///     Create a new <see cref="NonExistingEntity"/> with a given
        ///     entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        internal NonExistingEntity(Guid entity)
            : base(MessageForEntity(entity))
        {
            this.entity = entity;
        }

        private static string MessageForEntity(Guid entity)
        {
            return $"No entity with ID '${entity}' exists.";
        }

        private readonly Guid entity;

        /// <summary>
        ///     The IF of the entity that doesn't exist.
        /// </summary>
        internal Guid Entity
        {
            get
            {
                return entity;
            }
        }

        /// <summary>
        ///     Sets the <see cref="SerializationInfo"/> with info about this
        ///     <see cref="NonExistingEntity"/>.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo"/>.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext"/>.
        /// </param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(
            SerializationInfo info,
            StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Entity", typeof(Guid));
        }
    }
}
