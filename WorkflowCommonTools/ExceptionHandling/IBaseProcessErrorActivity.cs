using System;
using System.Activities;

namespace WorkflowCommonTools.ExceptionHandling
{

    public interface IBaseProcessErrorActivity
    {
        InArgument<Exception> Exception { get; set; }
    }
}
