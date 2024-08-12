using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.Interface;
using tafarrod.DAL.Database;
using tafarrod.DAL.Entities;
using tafarrod.DAL.Enums;

namespace tafarrod.BLL.Repository
{
    public class WorkerRepo :GenericRepo<Worker> ,IWorkerRepo
    {
        private readonly ApplicationDbContext dbContext;

        public WorkerRepo(ApplicationDbContext  dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Worker>> GetAll()
        {
            var data = await dbContext.Workers.Include(a => a.Nationality).Include(o => o.Occupation).ToListAsync();
            if (data == null)
            {
                throw new ArgumentException("Data is null", nameof(data));
            }
            return data;

        }

        public async Task<IEnumerable<Worker>> GetByAge(int age)
        {
            var data = await dbContext.Workers.Where(a => a.Age == age).Include(a=>a.Nationality).Include(o=>o.Occupation).ToListAsync();
            if(data==null)
            {
                throw new ArgumentException("Data is null", nameof(data));
            }
            return data;
           
        }

        public async Task<IEnumerable<Worker>> GetByExperience(PracticalExperience practicalExperience)
        {
            var data = await dbContext.Workers.Where(a => a.PracticalExperience == practicalExperience).Include(a => a.Nationality).Include(o => o.Occupation).ToListAsync();
            if (data == null)
            {
                throw new ArgumentException("Data is null", nameof(data));
            }
            return data;
        }

        public async Task<IEnumerable<Worker>> GetByNationalityId(int id)
        {
            var data = await dbContext.Workers.Where(a => a.NationalityId==id).Include(a => a.Nationality).Include(o => o.Occupation).ToListAsync();
            if (data == null)
            {
                throw new ArgumentException("Nationality  doesn't Exist ", nameof(data));
            }
            return data;
        }

        public async Task<IEnumerable<Worker>> GetByOccupationId(int id)
        {
            var data = await dbContext.Workers.Where(a => a.OccupationId==id).Include(a => a.Nationality).Include(o => o.Occupation).ToListAsync();
            if (data == null)
            {
                throw new ArgumentException("Occupation is null", nameof(data));
            }
            return data;
        }

        public async Task<IEnumerable<Worker>> GetByReligion(Religion religion)
        {
            var data = await dbContext.Workers.Where(a => a.Religion == religion).Include(a => a.Nationality).Include(o => o.Occupation).ToListAsync();
            if (data == null)
            {
                throw new ArgumentException("Religion is null", nameof(data));
            }
            return data;
        }



    }
}
