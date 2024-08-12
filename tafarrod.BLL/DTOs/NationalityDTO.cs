using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.ViewModel;
using tafarrod.DAL.Entities;

namespace tafarrod.BLL.DTOs
{
    public class NationalityDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public long RecruitmentPrice { get; set; }
        public int Period {  get; set; }
    }
}
