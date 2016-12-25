using MyWorkflowService.Models;

namespace MyWorkflowService.Services
{
    public interface IAccountService
    {
        Account CreateAccount(string name);
    }
}
