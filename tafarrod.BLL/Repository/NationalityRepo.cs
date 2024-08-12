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
    public class NationalityRepo :GenericRepo<Nationality> ,INationalityRepo
    {
        private readonly ApplicationDbContext dbContext;

        public NationalityRepo(ApplicationDbContext dbContext) :base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
