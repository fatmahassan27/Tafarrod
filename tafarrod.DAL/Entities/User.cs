using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tafarrod.DAL.Entities
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required,EmailAddress(ErrorMessage ="Invalid email format")]
      //  [UniqueEmail(ErrorMessage = "Email already exists")]  // Ensure this custom validation attribute is implemented
        public string Email {  get; set; }

        [Required,MaxLength(50)]
        public string Phone {  get; set; }
        [Required]
        public string UserName {  get; set; }
        [Required]
        public string Password {  get; set; }
    }
}
