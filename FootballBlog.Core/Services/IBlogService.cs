using FootballBlog.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballBlog.Core.Services
{
    public interface IBlogService
    {
        List<Blog> GetAllBlogs();
        Task CreateBlogAsync(Blog blog);
        Blog GetBlog(string id);
        void UpdateBlog(Blog blog);
    }
}
