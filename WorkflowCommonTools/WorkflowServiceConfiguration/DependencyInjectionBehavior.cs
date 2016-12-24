using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using WorkflowCommonTools.DependencyInjection;

namespace WorkflowCommonTools.WorkflowServiceConfiguration
{
    public class DependencyInjectionBehavior : IServiceBehavior
    {
        private readonly IUnityTypeRegistration _unityConfiguration;
        public DependencyInjectionBehavior(IUnityTypeRegistration unityConfiguration)
        {
            _unityConfiguration = unityConfiguration;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            if (serviceHostBase == null)
            {
                throw new ArgumentNullException("serviceHostBase");
            }

            var workflowServiceHost = serviceHostBase as WorkflowServiceHost;

            if (workflowServiceHost != null)
            {
                UnityConfiguration.InitializeUnityContainer(_unityConfiguration);
                var unityContainer = UnityConfiguration.GetConfiguredContainer();
                ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));

                // Add dependency extension to access unity configuration from the workflow activities.
                IDependencyInjectionExtension singletonDependencyInjectionExtension = new DependencyInjectionExtension();
                workflowServiceHost.WorkflowExtensions.Add(singletonDependencyInjectionExtension);
            }
        }
    }
}