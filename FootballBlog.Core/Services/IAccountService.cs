using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballBlog.Core.Services
{
    public interface IAccountService
    {
        Task<Guid> GetUserIdAsync();
    }
}
