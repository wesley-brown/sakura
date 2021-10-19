using System.Collections.Generic;

namespace Sakura.Bodies.RegisterBody
{
    /// <summary>
    ///     A presenter for a <see cref="System"/>.
    /// </summary>
    public interface Presenter
    {
        /// <summary>
        ///     Present a given <see cref="Output"/>.
        /// </summary>
        /// <param name="output">
        ///     The <see cref="Output"/> to present.
        /// </param>
        void Present(Output output);

        /// <summary>
        ///     Present a given list of input errors.
        /// </summary>
        /// <param name="inputErrors">
        ///     The input errors to present.
        /// </param>
        void PresentInputErrors(List<string> inputErrors);

        /// <summary>
        ///     Present a given list of output errors.
        /// </summary>
        /// <param name="outputErrors">
        ///     The output errors to present.
        /// </param>
        void PresentOutputErrors(List<string> outputErrors);
    }
}
