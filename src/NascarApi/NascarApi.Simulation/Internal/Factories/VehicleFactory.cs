using System.Collections.Generic;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Internal.Factories
{
    class VehicleFactory : Factory<NascarVehicle, int>
    {
        public override IList<NascarVehicle> GetList()
        {
            IList<NascarVehicle> items = new List<NascarVehicle>();

            for (int i = 0; i < 100; i++)
            {
                items.Add(new NascarVehicle()
                {
                    VehicleId = i,
                    DriverId = i
                });
            }

            return items;
        }
    }
}
