using ParkingLot.Enums;

namespace ParkingLot.Models
{
    public class Vehicle
    {
        public required string VehicleNo { get; set; }
        public SlotType SlotType { get; set; }
    }
}
