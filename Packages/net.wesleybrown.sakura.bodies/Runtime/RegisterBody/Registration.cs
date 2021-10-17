using System;
using UnityEngine;

namespace Sakura.Bodies.RegisterBody
{
    /// <summary>
    ///     A <see cref="System"/> that registers bodies.
    /// </summary>
    internal sealed class Registration : System
    {
        /// <summary>
        ///     Create a <see cref="Registration"/> made of a given
        ///     <see cref="Registrations"/> and <see cref="Presenter"/>.
        /// </summary>
        /// <param name="registrations">
        ///     The <see cref="Registrations"/>.
        /// </param>
        /// <param name="presenter">
        ///     The <see cref="Presenter"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="Registration"/> made of the given
        ///     <see cref="Registrations"/> and <see cref="Presenter"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="Registrations"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given <see cref="Presenter"/> is null.
        /// </exception>
        internal static Registration Of(
            Registrations registrations,
            Presenter presenter)
        {
            if (registrations == null)
                throw new ArgumentNullException(nameof(registrations));
            if (presenter == null)
                throw new ArgumentNullException(nameof(presenter));
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Register(
            Vector3 bodyLocation,
            Guid entity)
        {
            throw new NotImplementedException();
        }
    }
}
