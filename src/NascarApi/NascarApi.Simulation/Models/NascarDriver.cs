using NascarApi.Mock.Adapters;

namespace NascarApi.Mock.Models
{
    public class NascarDriver : IKeyedItem<int>
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        int IKeyedItem<int>.Id { get => DriverId; set => DriverId = value; }
    }
}
