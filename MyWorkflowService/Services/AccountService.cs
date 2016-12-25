using System;
using log4net;
using MyWorkflowService.Models;

namespace MyWorkflowService.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(AccountService));

        public Account CreateAccount(string name)
        {
            var account = new Account
            {
                Id   = Guid.NewGuid(),
                Name = name
            };

            _log.Debug($"Account: '{name}' created.");

            return account;
        }
    }
}
