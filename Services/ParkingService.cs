using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class ParkingService : IParkingService
    {
        public class AvailableSlots
        {            
            public int TwoWheeler { get; set; }
            public int FourWheeler { get; set; }
            public int HeavyWheeler { get; set; }

        }

        public static Dictionary<SlotType, int> _slots = new Dictionary<SlotType, int>();
        public static Dictionary<string, ParkingSpot> _parkingSpots = new Dictionary<string, ParkingSpot>();
        
        public void Initialise(int TwoWheelerSpace, int FourWheelerSpace, int HeavyWheelerSpace)
        {
            _slots.Add(SlotType.TwoWheeler, TwoWheelerSpace);
            _slots.Add(SlotType.FourWheeler, FourWheelerSpace);
            _slots.Add(SlotType.HeavyVehicle, HeavyWheelerSpace);
        }

        public AvailableSlots GetAvailableSlots()
        {
            return new AvailableSlots
            {
                TwoWheeler = _slots[SlotType.TwoWheeler],
                FourWheeler = _slots[SlotType.FourWheeler],
                HeavyWheeler = _slots[SlotType.HeavyVehicle]
            };
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            if (vehicle == null) 
                return;

            if (_slots[vehicle.SlotType] == 0)
                return;

            if (_parkingSpots.ContainsKey(vehicle.VehicleNo))
                return;

            ParkingSpot parkingSpot = new ParkingSpot
            {
                ParkingId = new Guid(),
                Vehicle = vehicle,
                TimeIn = DateTime.Now,
                TimeOut = null
            };
            _parkingSpots.Add(vehicle.VehicleNo, parkingSpot);
            _slots[vehicle.SlotType] -= 1;
        }

        public void UnParkVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                return;

            if (_slots[vehicle.SlotType] == 0)
                return;

            if (!_parkingSpots.ContainsKey(vehicle.VehicleNo))
                return;

            _parkingSpots.Remove(vehicle.VehicleNo);
            _slots[vehicle.SlotType] += 1;
        }

        public List<ParkingSpot> GetParkingSpots()
        {
            return _parkingSpots.Values.ToList();
        }
    }
}
