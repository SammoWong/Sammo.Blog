using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Repositories;

namespace Sammo.Blog.Repository.EntityFramework.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SammoDbContext sammoDbContext) : base(sammoDbContext)
        {
        }
    }
}
