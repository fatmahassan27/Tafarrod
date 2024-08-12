using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.DAL.Entities;
using tafarrod.DAL.Enums;

namespace tafarrod.BLL.ViewModel
{
    public class WorkerDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int NationalityId { get; set; }
        public string? NationalityName { get; set; }
         
        public long? RecruitmentPrice {  get; set; }
        public IFormFile Image { get; set; }
        public IFormFile CV { get; set; } 
        public int? OccupationId { get; set; } //elmhna
        public string? OccupationName { get; set; }
        public Religion? Religion { get; set; }
        public int Age { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public PracticalExperience PracticalExperience { get; set; }
        public int? ContractId { get; set; }
    }
}
