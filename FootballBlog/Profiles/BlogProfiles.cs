using AutoMapper;
using FootballBlog.Models.Data;
using FootballBlog.Web.ViewModels;

namespace FootballBlog.Web.Profiles
{
    public class BlogProfiles : Profile
    {
        public BlogProfiles()
        {
            CreateMap<BlogViewModel, Blog>();
            CreateMap<Blog, BlogViewModel>();
        }
    }
}
