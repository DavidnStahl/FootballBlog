using FootballBlog.Core.Services;
using FootballBlog.Web.Validation;
using FootballBlog.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballBlog.Web.Pages
{
    public class RegisterBase : ComponentBase
    {
        public RegisterViewModel RegisterViewModel { get; set; } = new RegisterViewModel();
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
            var result = await AccountService.IsEmailAlreadyRegisteredInTheSystem(RegisterViewModel.Email);
            if (result)
            {
                errors.Add(nameof(RegisterViewModel.Email), new List<string> { "Email is already taken" });
            }

            if (errors.Count() > 0)
            {
                CustomValidation.DisplayErrors(errors);
            }
            else
            {
                result = await AccountService.RegisterAsync(RegisterViewModel.Email, RegisterViewModel.Password);
                if(result)
                {
                    NavigationManager.NavigateTo("/login");
                }
            }
        }
    }
}
