using AutoMapper;
using FootballBlog.Core.Services;
using FootballBlog.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballBlog.Web.Pages
{
    public class IndexBase : ComponentBase
    {
        public List<BlogViewModel> BlogViewModel { get; set; } = new List<BlogViewModel>();

        [Inject]
        public IBlogService BlogService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();

            var bloggs = BlogService.GetAllBlogs();
            Mapper.Map(bloggs, BlogViewModel);
        }
    }
}
