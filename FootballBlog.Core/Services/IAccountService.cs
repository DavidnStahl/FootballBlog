using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballBlog.Core.Services
{
    public interface IAccountService
    {
        Task<Guid> GetUserIdAsync();
        Task<bool> LoginAsync(string email, string password, bool rememberMe);
        Task<bool> IsEmailAlreadyRegisteredInTheSystem(string email);
        Task<bool> RegisterAsync(string email, string password);
    }
}
