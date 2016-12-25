using System;
using MyWorkflowService.Models;

namespace MyWorkflowService.Services
{
    public class AccountService : IAccountService
    {
        public Account CreateAccount(string name)
        {
            var account = new Account
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            Console.WriteLine($"Creating account: '{name}'.");

            return account;
        }
    }
}
