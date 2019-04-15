using NascarApi.Mock.Adapters;

namespace NascarApi.Mock.Models
{
    public class NascarVehicle : IKeyedItem<int>
    {
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        int IKeyedItem<int>.Id { get => VehicleId; set => VehicleId = value; }
    }
}
