using Microsoft.Practices.Unity;
using MyWorkflowService.Services;
using WorkflowCommonTools.DependencyInjection;

namespace MyWorkflowService.DependencyInjection
{
    public class UnityTypeRegistration : IUnityTypeRegistration
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAccountService, AccountService>();
        }
    }
}
