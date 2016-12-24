using Microsoft.Practices.Unity;

namespace WorkflowCommonTools.DependencyInjection
{
    public class UnityConfiguration
    {
        private static IUnityContainer _container;

        /// <summary>
        ///     Initializes unity container and registers all the types.
        /// </summary>
        public static void InitializeUnityContainer(IUnityTypeRegistration unityConfiguration)
        {
            var container = new UnityContainer();
            unityConfiguration.RegisterTypes(container);
            _container = container;
        }

        /// <summary>
        ///     Gets the configured unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return _container;
        }
    }
}
