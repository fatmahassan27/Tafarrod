using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.Interface;

namespace tafarrod.DAL.CustomValidation
{
    public class UniqueUName : ValidationAttribute
    {
        private readonly IUserRepo userRepo;

        public UniqueUName(IUserRepo userRepo) 
        {
            this.userRepo = userRepo;
        }
        protected  async Task<ValidationResult?> IsValidAsync(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return new ValidationResult("Username is required");
            }
            string username = value.ToString();

            if (string.IsNullOrWhiteSpace(username))
            {
                return new ValidationResult("Username cannot be empty.");
            }
           var UserName= await  userRepo.GetByUsernameAsync(username);
           
            if (UserName == null)
            {
                throw new InvalidOperationException("User repository is not available.");
            }
            return ValidationResult.Success;
        }
    }
}
