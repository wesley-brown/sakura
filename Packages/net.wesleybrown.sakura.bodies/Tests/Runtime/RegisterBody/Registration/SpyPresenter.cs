using System.Collections.Generic;
using Sakura.Bodies.RegisterBody;

namespace Register_Body_System_Spec
{
    /// <summary>
    ///     A spy test double for a <see cref="Presenter"/>.
    /// </summary>
    internal sealed class SpyPresenter : Presenter
    {
        /// <summary>
        ///     The <see cref="Sakura.Bodies.RegisterBody.Output"/> that this
        ///     <see cref="SpyPresenter"/> was told to present.
        /// </summary>
        public Output Output { get; private set; }

        /// <summary>
        ///     The list of input errors that this <see cref="SpyPresenter"/>
        ///     was told to present.
        /// </summary>
        public List<string> InputErrors { get; private set; } =
            new List<string>();

        /// <summary>
        ///     The list of output errors that this <see cref="SpyPresenter"/>
        ///     was told to present.
        /// </summary>
        public List<string> OutputErrors { get; private set; } =
            new List<string>();

        /// <inheritdoc/>
        public void Present(Output output)
        {
            Output = output;
        }

        /// <inheritdoc/>
        public void PresentInputErrors(List<string> inputErrors)
        {
            InputErrors = new List<string>(inputErrors);
        }

        /// <inheritdoc/>
        public void PresentOutputErrors(List<string> outputErrors)
        {
            OutputErrors = new List<string>(outputErrors);
        }
    }
}
