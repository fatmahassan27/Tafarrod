using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.Interface;
using tafarrod.DAL.Database;
using tafarrod.DAL.Entities;

namespace tafarrod.BLL.Repository
{
    public class RoleRepo : GenericRepo<Role> ,IRoleRepo
    {
        private readonly ApplicationDbContext dbContext;

        public RoleRepo(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Role> GetByNameAsync(string name)
        {
            var data =  await  dbContext.Roles.Where(a=>a.Name==name).FirstOrDefaultAsync();
            return data;
        }
    }
}
