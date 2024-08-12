using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.Repository;
using tafarrod.DAL.Entities;
using tafarrod.DAL.Enums;

namespace tafarrod.BLL.Interface
{
    public interface IWorkerRepo : IGenericRepo<Worker> 
    {
        Task<IEnumerable<Worker>> GetAll();

        Task<IEnumerable<Worker>> GetByNationalityId(int id);
        Task<IEnumerable<Worker>> GetByOccupationId(int id);
        Task<IEnumerable<Worker>> GetByAge(int age);
        Task<IEnumerable<Worker>> GetByReligion(Religion religion);
        Task<IEnumerable<Worker>> GetByExperience(PracticalExperience practicalExperience);


    }
}
