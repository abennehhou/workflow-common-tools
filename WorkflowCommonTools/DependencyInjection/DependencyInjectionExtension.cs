using Microsoft.Practices.Unity;

namespace WorkflowCommonTools.DependencyInjection
{
    /// <summary>
    /// Extension used to inject unity in the workflows.
    /// </summary>
    public class DependencyInjectionExtension : IDependencyInjectionExtension
    {
        /// <summary>
        /// Unity dependency injection container.
        /// </summary>
        public IUnityContainer UnityContainer { get; set; }

        public DependencyInjectionExtension()
        {
            UnityContainer = UnityConfiguration.GetConfiguredContainer();
        }
    }
}
