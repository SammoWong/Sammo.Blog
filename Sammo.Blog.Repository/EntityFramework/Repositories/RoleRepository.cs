using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Repositories;

namespace Sammo.Blog.Repository.EntityFramework.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(SammoDbContext sammoDbContext) : base(sammoDbContext)
        {
        }
    }
}
