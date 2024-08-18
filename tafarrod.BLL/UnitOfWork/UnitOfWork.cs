using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.Interface;
using tafarrod.BLL.Repository;
using tafarrod.DAL.Database;

namespace tafarrod.BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private IWorkerRepo workerRepo;
        private IUserRepo userRepo;
        private INationalityRepo nationalityRepo;
        private IOccupationRepo occupationRepo;
        private IProblemRepo problemRepo;
        private IRoleRepo roleRepo;
        private IUserRoleRepo userRole;
        private ICallCenterRepo callCenterRepo;
        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public IWorkerRepo WorkerRepo
        {
            get
            {
                return workerRepo ??= new WorkerRepo(dbContext);
            }
        }

        public IUserRepo UserRepo
        {
            get
            {
                return userRepo ??= new UserRepo(dbContext);
            }
        }

        public INationalityRepo NationalityRepo
        {
            get
            {
                return nationalityRepo??= new NationalityRepo(dbContext);
            }
        }

        public IOccupationRepo OccupationRepo
        {
            get {
                return occupationRepo ??= new OccupationRepo(dbContext);    
            }
        }

        public IProblemRepo ProblemRepo
        {
            get
            {
                return problemRepo ??= new ProblemRepo(dbContext);
            }
        }

        public IRoleRepo RoleRepo
        {
            get
            {
                return roleRepo ??= new RoleRepo(dbContext);
            }
        }

        public IUserRoleRepo UserRoleRepo
        {
            get
            {
                return userRole ?? new UserRoleRepo(dbContext);
            }
        }

        public ICallCenterRepo CallCenterRepo
        {
            get
            {
                return callCenterRepo ??= new CallCenterRepo(dbContext);    
            }
        }

        public async Task<int> saveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
