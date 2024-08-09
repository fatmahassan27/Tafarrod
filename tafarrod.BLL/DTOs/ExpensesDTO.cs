using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tafarrod.BLL.DTOs
{
    public class ExpensesDTO
    {
        public int Id { get; set; }
        public double? Transportation { get; set; }
        public double? Housing { get; set; }
        public double? Food { get; set; }
        public double? Electricity { get; set; }
        public double? Water { get; set; }
        public double? Internet { get; set; }
        public double? TransferOfSponsorship { get; set; }
        public double? Other { get; set; }
        public int? ContractId { get; set; }
    }
}
