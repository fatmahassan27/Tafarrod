using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.DAL.Entities;

namespace tafarrod.BLL.Interface
{
    public interface IRoleRepo :IGenericRepo<Role>
    {
        Task<Role> GetByNameAsync(string name);
    }
}
