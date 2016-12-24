using System.Activities;
using Microsoft.Practices.Unity;
using WorkflowCommonTools.DependencyInjection;

namespace WorkflowCommonTools.Activities
{
    public abstract class BaseActivity : NativeActivity
    {
        /// <summary>
        /// Gets unity container from dependency injection extension.
        /// </summary>
        public IUnityContainer GetContainer(NativeActivityContext context)
        {
            var dependencyInjectionExtension = context.GetExtension<IDependencyInjectionExtension>();
            return dependencyInjectionExtension.UnityContainer;
        }
    }
}
