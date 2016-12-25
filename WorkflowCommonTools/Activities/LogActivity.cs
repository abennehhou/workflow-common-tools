using System.Activities;
using System.Diagnostics;
using log4net;

namespace WorkflowCommonTools.Activities
{
    /// <summary>
    ///     Activity used to log a message
    /// </summary>
    /// <typeparam name="T">Type of the class to log</typeparam>
    public sealed class LogActivity<T> : CodeActivity where T : new()
    {
        private readonly ILog _log = LogManager.GetLogger(typeof (T));

        /// <summary>
        ///     Level of the log : Fatal, Error, Warn, Info or Debug
        /// </summary>
        [RequiredArgument]
        public InArgument<TraceEventType> Loglevel { get; set; }

        /// <summary>
        ///     Message to log
        /// </summary>
        [RequiredArgument]
        public InArgument<string> Message { get; set; }

        /// <summary>
        ///     Runs the execution logic of the activity.
        /// </summary>
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the input arguments
            var criticity = context.GetValue(Loglevel);
            var message = context.GetValue(Message);
            switch (criticity)
            {
                case TraceEventType.Critical:
                    _log.Fatal(message);
                    break;
                case TraceEventType.Error:
                    _log.Error(message);
                    break;
                case TraceEventType.Warning:
                    _log.Warn(message);
                    break;
                case TraceEventType.Information:
                    _log.Info(message);
                    break;
                case TraceEventType.Verbose:
                    _log.Debug(message);
                    break;
                default:
                    _log.Debug(message);
                    break;
            }
        }
    }
}