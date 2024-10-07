using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicPortal.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        // Engine Size Properties
        [Display(Name = "Engine Size")]
        [DataType(DataType.Text)]
        public decimal EngineS { get; set; }
        //
        // Registered Date Properties
        [Display(Name = "First Registered")]
        [DataType(DataType.Date)]
        public DateTime FirstRegistered { get; set; }
        //
        // Bool Registered Properties
        [Display(Name = "Registered")]
        public bool IsRegistered { get; set; }
        //
        // Bool MOT Properties
        [Display(Name = "MOT?")]
        public bool IsMOTd { get; set; }
        //
        // MOT Time Date Properties
        [Display(Name = "MOT Time")]
        [DataType(DataType.Date)]
        public DateTime MOTTime { get; set; }
        //
        // Price Properties
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        //
    }
}
