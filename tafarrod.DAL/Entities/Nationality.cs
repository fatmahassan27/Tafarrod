using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tafarrod.DAL.Entities
{
    public class Nationality
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Worker> workers { get; set; } = new HashSet<Worker>();
        public long RecruitmentPrice { get; set; }
        public int Period {  get; set; }

    }
}
