using System;
using System.Activities;
using System.ServiceModel;

namespace MyWorkflowService.ExceptionHandling
{
    /// <summary>
    /// Creates a fault exception from an exception.
    /// </summary>
    public sealed class CreateFault : CodeActivity
    {
        public InArgument<Exception> Exception { get; set; }

        public OutArgument<FaultException> FaultException { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var exception = context.GetValue(Exception);
            var fault = new FaultException(exception.Message);
            context.SetValue(FaultException, fault);
        }
    }
}
