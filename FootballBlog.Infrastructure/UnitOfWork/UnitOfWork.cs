using FootballBlog.Infrastructure.Repository.Entities.BlogRepository;
using FootballBlog.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBlog.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;
        public UnitOfWork(BlogContext context)
        {
            _context = context;
            Blog = new BlogRepository(_context);
        }

        public IBlogRepository Blog { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
