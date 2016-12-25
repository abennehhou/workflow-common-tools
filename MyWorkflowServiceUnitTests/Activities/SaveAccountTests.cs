using System.Activities;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWorkflowService.Activities;
using MyWorkflowService.Models;
using MyWorkflowService.Services;
using NUnit.Framework;
using WorkflowCommonTools.DependencyInjection;
using Assert = NUnit.Framework.Assert;

namespace MyWorkflowServiceUnitTests.Activities
{
    [TestClass]
    public class SaveAccountTests
    {
        private Mock<IAccountService> _accountServiceMock;
        private Mock<IDependencyInjectionExtension> _dependencyInjectionExtensionMock;
        private WorkflowInvoker _invoker;
        private Mock<IUnityContainer> _unityContainerMock;

        private const string IN_ARGUMENT_NAME = "Name";
        private const string OUT_ARGUMENT_ACCOUNT = "Account";

        [TestInitialize]
        public void Init()
        {
            var activity = new CreateAccount();
            _invoker = new WorkflowInvoker(activity);
            _dependencyInjectionExtensionMock = new Mock<IDependencyInjectionExtension>();
            _unityContainerMock = new Mock<IUnityContainer>();
            _accountServiceMock = new Mock<IAccountService>();
            _invoker.Extensions.Add(_dependencyInjectionExtensionMock.Object);
            _dependencyInjectionExtensionMock.SetupGet(x => x.UnityContainer).Returns(_unityContainerMock.Object);
            _unityContainerMock.Setup(x => x.Resolve(typeof(IAccountService), null)).Returns(_accountServiceMock.Object);
        }

        public void VerifyAllMocks()
        {
            _unityContainerMock.VerifyAll();
            _dependencyInjectionExtensionMock.VerifyAll();
            _accountServiceMock.VerifyAll();
        }

        [TestMethod]
        public void CreateAccount_CallsAccountService_WithValidParameters()
        {
            // Arrange
            var name = "my company name";
            var input = new Dictionary<string, object>
            {
                { IN_ARGUMENT_NAME, name }
            };

            var expectedAccount = new Account { Name = name };
            _accountServiceMock.Setup(x => x.CreateAccount(name)).Returns(expectedAccount);

            // Act
            var result = _invoker.Invoke(input);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ContainsKey(OUT_ARGUMENT_ACCOUNT), Is.True);
            Assert.That(result[OUT_ARGUMENT_ACCOUNT], Is.EqualTo(expectedAccount));
            VerifyAllMocks();
        }
    }
}
