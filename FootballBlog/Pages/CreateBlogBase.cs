using AutoMapper;
using FootballBlog.Core.Services;
using FootballBlog.Models.Data;
using FootballBlog.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballBlog.Web.Pages
{
    public class CreateBlogBase : ComponentBase
    {
        public BlogViewModel BlogViewModel { get; set; } = new BlogViewModel();

        [Inject]
        public IBlogService BlogService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<string> Categories { get; set; } = new List<string> { "Premier League", "Allsvenskan", "La Liga", "Bundesliga", "Lige 1" };

        protected override void OnInitialized()
        {
            base.OnInitialized();
            BlogViewModel.Category = Categories[0];
            BlogViewModel.Published = false;
        }
        protected async Task HandleValidSubmit()
        {
            var blog = new Blog();
            Mapper.Map(BlogViewModel, blog);
            await BlogService.CreateBlogAsync(blog);
            NavigationManager.NavigateTo("/");
        }
    }
}
