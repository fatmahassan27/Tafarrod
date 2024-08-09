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
        public string Nationality { get; set; }
        public string Image {  get; set; }
        public byte[] CV { get; set; } // Binary data for file storage
        public string Occupation { get; set; } //elmhna
        public Religion? Religion {  get; set; }
       public long  RecruitmentPrice { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public PracticalExperience PracticalExperience { get; set; }
        public int ContractId {  get; set; }
        public Contract Contract { get; set; }

    }
}
