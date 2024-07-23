namespace ParkingLot.Models
{
    public class ParkingSpot
    {
        public Guid ParkingId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }
}
