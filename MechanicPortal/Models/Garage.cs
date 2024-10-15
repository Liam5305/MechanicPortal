using System.ComponentModel.DataAnnotations;

namespace MechanicPortal.Models
{
    public class Garage
    {
        [Required]
        public int GarageId { get; set; }
        
        [Required]
        [Display(Name = "Garage Name")]
        public string GarageName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Garage Desc")]
        public string GarageDescription { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Garage Type")]
        public string GarageType { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Garage Location")]
        public string GarageLocation { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Assigned Employee")]
        public string AssignedEmployee { get; set; } = string.Empty;
    }
}
