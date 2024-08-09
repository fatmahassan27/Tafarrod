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
    public class UserRepo : GenericRepo<User> ,IUserRepo
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepo(ApplicationDbContext dbContext) :base(dbContext)
        {
            this.dbContext = dbContext;
        }

        

        public async Task<User> GetByEmailAsync(string email)
        {
            
            var data =  await dbContext.Users.Where(a => a.Email == email).FirstOrDefaultAsync();
            if(data==null)
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }
            return data;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var data = await dbContext.Users.Where(a=>a.UserName==username).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(username));
            }
            return data;
        }
    }
}
