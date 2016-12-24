using System;

namespace MyWorkflowService.Services
{
    public class AccountService : IAccountService
    {
        public void SaveAccount(string name)
        {
            Console.WriteLine($"Saving account: '{name}'.");
        }
    }
}
