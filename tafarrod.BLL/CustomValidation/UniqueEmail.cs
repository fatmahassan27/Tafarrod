using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.Interface;

namespace tafarrod.BLL.CustomValidation
{
    public class UniqueEmail :ValidationAttribute
    {
        private readonly IUserRepo userRepo;

        public UniqueEmail(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }


        protected  async Task<ValidationResult?> IsValid(object? value, ValidationContext validationContext)
        { 
            if(value == null)
            {
                return new ValidationResult("Email is required");
            }
            string email = value.ToString();

            if (string.IsNullOrWhiteSpace(email))
            {
                return new ValidationResult("email cannot be empty.");
            }
            var UEmail =  await userRepo.GetByEmailAsync(email);
            if(UEmail == null)
            {
                throw new InvalidOperationException("User repository is not available.");

            }
            return ValidationResult.Success;

        }

    }
}
