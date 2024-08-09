using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tafarrod.DAL.Entities
{
    public class Contract
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string CustomerName {  get; set; }
        public long ContractNumber { get; set; }
        public DateTime? CustomerDate { get; set; }//Customer contract date
        public DateTime? DateAgency { get; set; }// Date of the contract with the foreign agency 
        public int WorkerId {  get; set; }
        [ForeignKey("WorkerId")]
        public Worker Worker { get; set; }
    }
}
