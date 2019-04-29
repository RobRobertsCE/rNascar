using NascarApi.Simulation.Adapters;

namespace NascarApi.Simulation.Models
{
    public class NascarVehicle : IKeyedItem<int>
    {
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        int IKeyedItem<int>.Id { get => VehicleId; set => VehicleId = value; }
    }
}
