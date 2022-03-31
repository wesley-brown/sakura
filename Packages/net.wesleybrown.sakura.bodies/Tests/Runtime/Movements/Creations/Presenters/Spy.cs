using System.Collections.Generic;
using Sakura.Bodies.Movements.Creations;

namespace Movement_Creation_System_Spec.Presenters
{
    /// <summary>
    ///     A spy test double that records the inputs it receives.
    /// </summary>
    internal sealed class Spy : OutputPort
    {
        /// <summary>
        ///     The output received by this spy.
        /// </summary>
        public Output Output { get; private set; }

        /// <summary>
        ///     The validation errors received by this spy.
        /// </summary>
        public IList<string> ValidaitonErrors { get; private set; } =
            new List<string>();

        /// <summary>
        ///     The processing errors received by this spy.
        /// </summary>
        public IList<string> ProcessingErrors { get; private set; } =
            new List<string>();

        /// <summary>
        ///     Called when a movement is successfully created.
        /// </summary>
        /// <param name="output">
        ///     The output containing the created movement data.
        /// </param>
        public void OnCreation(Output output)
        {
            Output = output;
        }

        /// <summary>
        ///     Called when errors were encountered while validating the input
        ///     data.
        /// </summary>
        /// <param name="validationErrors">
        ///     The validation errors.
        /// </param>
        public void OnValidationError(IList<string> validationErrors)
        {
            ValidaitonErrors = validationErrors;
        }

        /// <summary>
        ///     Called when errors were encountered while processing the valid
        ///     input data to create a movement.
        /// </summary>
        /// <param name="processingErrors">
        ///     The processing errors.
        /// </param>
        public void OnProcessingError(IList<string> processingErrors)
        {
            ProcessingErrors = processingErrors;
        }
    }
}
