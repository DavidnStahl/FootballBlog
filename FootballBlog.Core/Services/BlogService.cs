using FootballBlog.Infrastructure.Repository.Entities.BlogRepository;
using FootballBlog.Infrastructure.UnitOfWork;
using FootballBlog.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBlog.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;

        public BlogService(BlogContext context, IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }
        public async Task CreateBlogAsync(Blog blog)
        {
            blog.CreatedOn = DateTime.Now;
            blog.Id = Guid.NewGuid();
            blog.UserId = await _accountService.GetUserIdAsync();

            _unitOfWork.Blog.Add(blog);
        }

        public List<Blog> GetAllBlogs()
        {
            var blogList = _unitOfWork.Blog.GetAll().ToList();

            return blogList?.OrderBy(x => x.CreatedOn).ToList();
        }

        public Blog GetBlog(string id)
        {
            return _unitOfWork.Blog.FindById(Guid.Parse(id));
        }

        public void UpdateBlog(Blog blog)
        {
            _unitOfWork.Blog.Edit(blog);
        }
    }
}
