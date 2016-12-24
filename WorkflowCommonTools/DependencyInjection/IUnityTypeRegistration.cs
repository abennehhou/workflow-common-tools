using Microsoft.Practices.Unity;

namespace WorkflowCommonTools.DependencyInjection
{
    public interface IUnityTypeRegistration
    {
        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        void RegisterTypes(IUnityContainer container);
    }
}
