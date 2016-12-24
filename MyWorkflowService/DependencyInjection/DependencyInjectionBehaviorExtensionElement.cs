using System;
using System.ServiceModel.Configuration;
using WorkflowCommonTools.WorkflowServiceConfiguration;

namespace MyWorkflowService.DependencyInjection
{
    public class DependencyInjectionBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof (DependencyInjectionBehavior); }
        }

        protected override object CreateBehavior()
        {
            var behavior = new DependencyInjectionBehavior(new UnityTypeRegistration());

            return behavior;
        }
    }
}
