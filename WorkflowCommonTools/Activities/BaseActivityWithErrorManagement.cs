using System;
using System.Activities;
using log4net;
using WorkflowCommonTools.ExceptionHandling;

namespace WorkflowCommonTools.Activities
{
    public abstract class BaseActivityWithErrorManagement<T> : BaseActivity where T : Activity, IBaseProcessErrorActivity, new()
    {
        #region Variables

        //Variables are created to be exposed to the runtime
        private readonly Variable<Exception> _exceptionVariable;

        #endregion

        private readonly ILog _log = LogManager.GetLogger(typeof(BaseActivityWithErrorManagement<T>).Name);


        /// <summary>
        ///     The ProcessErrors activity is executed when an error is handled.
        /// </summary>
        private T _processErrorActivity;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        protected BaseActivityWithErrorManagement()
        {
            _exceptionVariable = new Variable<Exception>();
        }

        /// <summary>
        ///     Override CacheMetadata to give more information to the runtime
        /// </summary>
        /// <param name="metadata">Encapsulates the activity’s arguments, variables, child activities, and activity delegates.</param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddImplementationVariable(_exceptionVariable);

            _processErrorActivity = new T
            {
                Exception = new InArgument<Exception>(_exceptionVariable)
            };
            metadata.AddImplementationChild(_processErrorActivity);
            base.CacheMetadata(metadata);
        }

        /// <summary>
        ///     Override Execute to run the DoWork method in this execution.
        ///     It shouldn't be implemented in a derived class
        /// </summary>
        protected override void Execute(NativeActivityContext context)
        {
            try
            {
                DoWork(context);
            }
            catch (Exception exception)
            {
                _log.Debug(exception);
                _exceptionVariable.Set(context, exception);
                context.ScheduleActivity(_processErrorActivity, OnHandlingErrorCompleted, OnHandlingErrorFaulted);
            }
        }

        private void OnHandlingErrorFaulted(NativeActivityFaultContext faultContext, Exception propagatedException, ActivityInstance propagatedFrom)
        {
            _log.Error(propagatedException);
            throw propagatedException;
        }

        protected virtual void OnHandlingErrorCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            _log.Debug("Handling error completed");
        }

        /// <summary>
        ///     This method runs the execution logic of the derived class.
        /// </summary>
        protected abstract void DoWork(NativeActivityContext context);
    }
}
