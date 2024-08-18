using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tafarrod.DAL.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } // For example, "Admin", "User", etc.

        // Navigation property for the users associated with this role
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
