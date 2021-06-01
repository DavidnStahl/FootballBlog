using FootballBlog.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballBlog.Web.Components
{
    public class BlogTeaserBase : ComponentBase
    {
        [Parameter]
        public BlogViewModel BlogViewModel { get; set; }

        protected override void OnInitialized()
        {
        }
    }
}
