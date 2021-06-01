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
    public class EditBlogBase : ComponentBase
    {
        [Inject]
        public IBlogService BlogService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public List<string> Categories { get; set; } = new List<string> { "Premier League", "Allsvenskan", "La Liga", "Bundesliga", "Lige 1" };
        public BlogViewModel BlogViewModel { get; set; } = new BlogViewModel();

        protected Blog Blog { get; set; }

        [Parameter]
        public string Id { get; set; }
        protected override void OnInitialized()
        {
            Blog = BlogService.GetBlog(Id);
            Mapper.Map(Blog, BlogViewModel);
        }
        protected void HandleValidSubmit()
        {
            Blog.EditedOn = DateTime.Now;
            Blog.Text = BlogViewModel.Text;
            Blog.Category = BlogViewModel.Category;
            Blog.Title = BlogViewModel.Title;
            Blog.Published = BlogViewModel.Published;

            BlogService.UpdateBlog(Blog);
            NavigationManager.NavigateTo("/");
        }
    }
}
