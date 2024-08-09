using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.Interface;
using tafarrod.DAL.Database;

namespace tafarrod.BLL.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepo(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(T obj)
        {
            await dbContext.Set<T>().AddAsync(obj);
        }

        public async Task DeleteAsync(int id)
        {
            var data = await dbContext.Set<T>().FindAsync(id);
            if (data != null)
            {
                dbContext.Set<T>().Remove(data);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
