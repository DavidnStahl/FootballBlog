using FootballBlog.Infrastructure.Repository.Generic;
using FootballBlog.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBlog.Infrastructure.Repository.Entities.BlogRepository
{
    public class BlogRepository : EntityRepository<Blog> , IBlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository(BlogContext context) : base (context)
        {
            _context = context;
        }
    }
}
