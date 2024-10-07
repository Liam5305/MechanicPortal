namespace MechanicPortal.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string EngineS { get; set; }
        public DateTime FirstRegistered { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsMOTd { get; set; } 
        public DateTime MOTTime { get; set; }
        public decimal Price { get; set; }

    }
}
