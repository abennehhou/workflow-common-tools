using System;
using System.Activities;
using log4net;
using Microsoft.Practices.Unity;
using MyWorkflowService.ExceptionHandling;
using MyWorkflowService.Models;
using MyWorkflowService.Services;
using WorkflowCommonTools.Activities;

namespace MyWorkflowService.Activities
{
    public sealed class CreateAccount : BaseActivityWithErrorManagement<ProcessError>
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(CreateAccount));

        private const string FORBIDDEN_NAME = "42";

        public InArgument<string> Name { get; set; }

        public OutArgument<Account> Account { get; set; }

        protected override void DoWork(NativeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var name = context.GetValue(Name);
            _log.Debug($"CreateAccount called wih parameters: {name}");

            if (name == FORBIDDEN_NAME)
                throw new Exception($"Name '{name}' is forbidden.");

            // Create account
            var container = GetContainer(context);
            var accountService = container.Resolve<IAccountService>();
            var account = accountService.CreateAccount(name);

            // Set out argument
            context.SetValue(Account, account);
        }
    }
}