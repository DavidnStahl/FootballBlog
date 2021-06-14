using FootballBlog.Core.Services;
using FootballBlog.Web.Validation;
using FootballBlog.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballBlog.Web.Pages
{
    public class LoginBase : ComponentBase
    {
        public LoginViewModel LoginViewModel { get; set; } = new LoginViewModel();
        [Inject]
        public IAccountService AccountService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CustomValidation CustomValidation { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();            
        }

        protected async Task HandleValidSubmitAsync()
        {
            CustomValidation.ClearErrors();
            var errors = new Dictionary<string, List<string>>();

            var result = await AccountService.LoginAsync(LoginViewModel.Email, LoginViewModel.Password, LoginViewModel.RememberMe);
            if (!result)
            {
                errors.Add(nameof(LoginViewModel.LoginSucced), new List<string> { "Invalid login attempt." });
            }

            if (errors.Count() > 0)
            {
                CustomValidation.DisplayErrors(errors);
            }
            else
            {
                if (result)
                {
                    NavigationManager.NavigateTo("/");
                }
            }
        }        
    }
}
