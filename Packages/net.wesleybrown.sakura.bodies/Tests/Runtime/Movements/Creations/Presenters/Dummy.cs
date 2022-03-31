using System.Collections.Generic;
using Sakura.Bodies.Movements.Creations;

namespace Movement_Creation_System_Spec.Presenters
{
    internal sealed class Dummy : OutputPort
    {
        public void OnCreation(Output output)
        {
            throw new System.NotImplementedException();
        }

        public void OnValidationError(IList<string> validationErrors)
        {
            throw new System.NotImplementedException();
        }

        public void OnProcessingError(IList<string> processingError)
        {
            throw new System.NotImplementedException();
        }
    }
}
