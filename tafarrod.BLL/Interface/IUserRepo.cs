using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.DAL.Entities;

namespace tafarrod.BLL.Interface
{
    public interface IUserRepo :IGenericRepo<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);


    }
}
