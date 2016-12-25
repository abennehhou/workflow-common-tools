Workflow Common Tools
===================

# Introduction

The goal of this project is to provide some useful tools for Workflow Foundation.

# Composition

The solution contains three projects:
- WorkflowCommonTools: the library containing all the tools
- MyWorkflowService: a WCF workflow service application using the library. Used to demontrate how to use the library.
- MyWorkflowServiceUnitTests: Unit test project for the workflow service.

# Current features

- Dependency injection using Unity
- Logging activity using log4net
- Global exception handling

### Dependency injection

In the project using WorkflowCommonTools library:
* Use Unity nuget package
* Create a class implementing IUnityTypeRegistration and register all the instances
* Create a BehaviorExtensionElement using DependencyInjectionBehavior with the created class

To resolve an instance in a code activity:
* Inherit from BaseActivity and use:
```sh
var container = GetContainer(context);
var myImplementation = container.Resolve<MyInterface>();
```

### Logging

To use logging:
* Use log4net nuget package
* Add assembly level attribute `[assembly: log4net.Config.XmlConfigurator(Watch = true)]`
* Configure log4net in Web.config file

To use LogActivity in xaml file:
* Search LogActivity in toolbox (namespace WorkflowCommonTools.Activities)
* Drag-and-drop and search for the type cooresponding to your xaml activity.
* Fill the LogLevel (TraceEventType) and the message (string)

### Global exception handling

To use global exception handling:
* Create the activity that handles the exceptions (example *ProcessError*).
    * It must implement the `IBaseProcessErrorActivity` interface
    * If the activity is a xaml activity (example *ProcessError.xaml*), create a partial class (*ProcessError.cs*) implementing the interface.
    * In this activity, implement all the processing for exception handling. Example: transform the exception, save the error in database, log it...
* To handle exceptions in code activities, they must inherit from `BaseActivityWithErrorManagement<ProcessError>`
