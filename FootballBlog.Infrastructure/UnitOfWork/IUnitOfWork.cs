using FootballBlog.Infrastructure.Repository.Entities.BlogRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBlog.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blog { get; }
        int Complete();
    }
}
