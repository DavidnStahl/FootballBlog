using FootballBlog.Infrastructure.Repository.Generic;
using FootballBlog.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBlog.Infrastructure.Repository.Entities.BlogRepository
{
    public interface IBlogRepository : IEntityRepository<Blog>
    {
    }
}
