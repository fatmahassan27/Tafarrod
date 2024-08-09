using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.Interface;

namespace tafarrod.BLL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IWorkerRepo WorkerRepo { get; }
        IUserRepo UserRepo { get; }
        Task<int> saveAsync();


    }
}
