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

# Next steps
- Add global exception handling