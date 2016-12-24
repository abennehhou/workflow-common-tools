using System.Activities;
using Microsoft.Practices.Unity;
using MyWorkflowService.Services;
using WorkflowCommonTools.Activities;

namespace MyWorkflowService.Activities
{
    public sealed class SaveAccount : BaseActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Name { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(NativeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var name = context.GetValue(Name);
            var container = GetContainer(context);
            var accountService = container.Resolve<IAccountService>();
            accountService.SaveAccount(name);
        }
    }
}
