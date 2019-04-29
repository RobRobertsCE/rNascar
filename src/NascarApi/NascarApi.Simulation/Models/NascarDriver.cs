using NascarApi.Simulation.Adapters;

namespace NascarApi.Simulation.Models
{
    public class NascarDriver : IKeyedItem<int>
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        int IKeyedItem<int>.Id { get => DriverId; set => DriverId = value; }
    }
}
