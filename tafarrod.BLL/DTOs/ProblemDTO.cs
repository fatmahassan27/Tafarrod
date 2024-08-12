using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.DAL.Enums;

namespace tafarrod.BLL.DTOs
{
    public class ProblemDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public Subject Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
