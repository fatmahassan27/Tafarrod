using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.CustomValidation;
using tafarrod.BLL.Interface;
using tafarrod.DAL.CustomValidation;

namespace tafarrod.BLL.DTOs
{
    public class RegistrationDTO
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(50)]
        public string Phone { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required,Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
