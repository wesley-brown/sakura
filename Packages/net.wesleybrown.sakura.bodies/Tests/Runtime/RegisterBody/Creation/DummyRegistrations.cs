﻿using System;
using Sakura.Bodies.Core;
using Sakura.Bodies.RegisterBody;

namespace Register_Body_System_Spec
{
    /// <summary>
    ///     A dummy test double for a <see cref="Registrations"/>.
    /// </summary>
    internal sealed class DummyRegistrations : Registrations
    {
        /// <summary>
        ///     Add a <see cref="Body"/> that represents a given entity.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public void Add(
            Body body,
            Guid entity)
        {
            throw new NotImplementedException();
        }
    }
}
