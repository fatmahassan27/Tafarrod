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
    public class Worker
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }
        public string Image {  get; set; }
        public string CV { get; set; } 
        public int? OccupationId { get; set; } //elmhna
        [ForeignKey("OccupationId")]
        public Occupation? Occupation { get; set; }
        public Religion? Religion {  get; set; }
        public int Age {  get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public PracticalExperience PracticalExperience { get; set; }
        public int ContractId {  get; set; }
        public Contract Contract { get; set; }

    }
}
