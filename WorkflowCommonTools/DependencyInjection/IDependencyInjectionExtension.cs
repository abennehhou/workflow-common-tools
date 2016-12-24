using Microsoft.Practices.Unity;

namespace WorkflowCommonTools.DependencyInjection
{
    /// <summary>
    /// Extension used to inject unity in the workflows.
    /// </summary>
    public interface IDependencyInjectionExtension
    {
        /// <summary>
        /// Unity dependency injection container.
        /// </summary>
        IUnityContainer UnityContainer { get; set; }
    }
}
