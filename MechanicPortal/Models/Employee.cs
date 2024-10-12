using Microsoft.Data.Sqlite;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace MechanicPortal.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "First name must be more than 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20, ErrorMessage = "Last name cannot be more than 20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public string DoB { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        private bool _Active;

        public bool Active
        {
            set { _Active = value; } get { return _Active; }
        }
    }
}
