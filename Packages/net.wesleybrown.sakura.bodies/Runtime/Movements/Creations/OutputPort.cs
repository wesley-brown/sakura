using System.Collections.Generic;

namespace Sakura.Bodies.Movements.Creations
{
    /// <summary>
    ///     The output port for a movement creation system.
    /// </summary>
    public interface OutputPort
    {
        /// <summary>
        ///     Called when a movement is successfully created.
        /// </summary>
        /// <param name="output">
        ///     The output containing the created movement data.
        /// </param>
        void OnCreation(Output output);

        /// <summary>
        ///     Called when errors were encountered while validating the input
        ///     data.
        /// </summary>
        /// <param name="validationErrors">
        ///     The validation errors.
        /// </param>
        void OnValidationError(IList<string> validationErrors);

        /// <summary>
        ///     Called when errors were encountered while processing the valid
        ///     input data to create a movement.
        /// </summary>
        /// <param name="processingError">
        ///     The processing errors.
        /// </param>
        void OnProcessingError(IList<string> processingError);
    }
}
