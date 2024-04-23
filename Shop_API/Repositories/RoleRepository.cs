using Microsoft.EntityFrameworkCore;
using Shop_API.Context;
using Shop_API.Entities;
using Shop_API.Repositories.Interface;

namespace Shop_API.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
