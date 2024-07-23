using ParkingLot.Models;
using static ParkingLot.Services.ParkingService;

namespace ParkingLot.Interfaces
{
    public interface IParkingService
    {
        void Initialise(int TwoWheelerSpace, int FourWheelerSpace, int HeavyWheelerSpace);
        AvailableSlots GetAvailableSlots();
        void ParkVehicle(Vehicle vehicle);
        void UnParkVehicle(Vehicle vehicle);
        List<ParkingSpot> GetParkingSpots();
    }
}
