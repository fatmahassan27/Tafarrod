using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tafarrod.DAL.Entities
{
    public class Occupation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
