using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.DAL.Enums;

namespace tafarrod.DAL.Entities
{
    public class Problem
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber {  get; set; }
        public Subject Subject { get; set; }
        [Required]
        public string Message {  get; set; }
    }
}
