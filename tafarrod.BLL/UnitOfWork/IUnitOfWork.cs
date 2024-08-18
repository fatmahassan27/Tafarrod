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
        INationalityRepo NationalityRepo { get; }
        IOccupationRepo OccupationRepo { get; } 
        IProblemRepo ProblemRepo { get; }
        IRoleRepo RoleRepo { get; }
        IUserRoleRepo UserRoleRepo { get; }
        ICallCenterRepo CallCenterRepo { get; }
        Task<int> saveAsync();


    }
}
