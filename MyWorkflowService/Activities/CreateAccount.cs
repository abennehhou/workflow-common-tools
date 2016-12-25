﻿using System.Activities;
using log4net;
using Microsoft.Practices.Unity;
using MyWorkflowService.Models;
using MyWorkflowService.Services;
using WorkflowCommonTools.Activities;

namespace MyWorkflowService.Activities
{
    public sealed class CreateAccount : BaseActivity
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(CreateAccount));

        public InArgument<string> Name { get; set; }

        public OutArgument<Account> Account { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(NativeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var name = context.GetValue(Name);
            _log.Debug($"CreateAccount called wih parameters: {name}");

            // Create account
            var container = GetContainer(context);
            var accountService = container.Resolve<IAccountService>();
            var account = accountService.CreateAccount(name);

            // Set out argument
            context.SetValue(Account, account);
        }
    }
}