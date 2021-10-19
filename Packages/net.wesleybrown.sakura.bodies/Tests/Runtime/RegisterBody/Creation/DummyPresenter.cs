using System;
using System.Collections.Generic;
using Sakura.Bodies.RegisterBody;

namespace Register_Body_System_Spec
{
    /// <summary>
    ///     A dummy test double for a <see cref="Presenter"/>.
    /// </summary>
    internal sealed class DummyPresenter : Presenter
    {
        /// <summary>
        ///     Present a given <see cref="Output"/>.
        /// </summary>
        /// <param name="output">
        ///     The <see cref="Output"/> to present.
        /// </param>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public void Present(Output output)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Present a given list of input errors.
        /// </summary>
        /// <param name="inputErrors">
        ///     The input errors to present.
        /// </param>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public void PresentInputErrors(List<string> inputErrors)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Present a given list of output errors.
        /// </summary>
        /// <param name="outputErrors">
        ///     The output errors to present.
        /// </param>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public void PresentOutputErrors(List<string> outputErrors)
        {
            throw new NotImplementedException();
        }
    }
}
