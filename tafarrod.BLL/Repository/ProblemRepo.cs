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
    public class ProblemRepo :GenericRepo<Problem> ,IProblemRepo
    {
        private readonly ApplicationDbContext dbContext;

        public ProblemRepo(ApplicationDbContext dbContext) :base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
