using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace FootballBlog.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Guid> GetUserIdAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return Guid.Parse(user.Id);
        }

        public async Task<bool> LoginAsync(string email, string password, bool rememberMe)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(email);
                var result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                new Exception(e.Message.ToString());
                return false;
            }
        }
           
        public async Task<bool> IsEmailAlreadyRegisteredInTheSystem(string email)
        {
            var result = await _userManager.FindByNameAsync(email);
            return result != null;
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            await _signInManager.SignInAsync(user, false);
            if(result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
