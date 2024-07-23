using Microsoft.AspNetCore.Mvc;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using static ParkingLot.Services.ParkingService;

namespace ParkingLot.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {

        IParkingService _parkingService;

        public ParkingLotController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpGet]
        public void Initialise()
        {
            _parkingService.Initialise(10, 10, 10);
        }

        [HttpGet]
        public ActionResult<AvailableSlots> GetAvailableSlots()
        {
            return Ok(_parkingService.GetAvailableSlots());
        }

        [HttpPost]
        public void ParkVehicle(Vehicle vehicle)
        {
            _parkingService.ParkVehicle(vehicle);
        }

        [HttpPost]
        public void UnParkVehicle(Vehicle vehicle)
        {
            _parkingService.UnParkVehicle(vehicle);
        }

        [HttpGet]
        public ActionResult<List<ParkingSpot>> GetParkingSpots()
        {
            return Ok(_parkingService.GetParkingSpots());
        }
    }
}
