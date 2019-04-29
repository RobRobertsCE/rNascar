using System.Collections.Generic;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Internal.Factories
{
    class DriverFactory : Factory<NascarDriver, int>
    {
        public override IList<NascarDriver> GetList()
        {
            IList<NascarDriver> items = new List<NascarDriver>();

            items.Add(new NascarDriver()
            {
                DriverId = 1,
                DriverName = "Kurt Busch"
            });
            items.Add(new NascarDriver()
            {
                DriverId = 2,
                DriverName = "Brad Keselowski"
            });
            items.Add(new NascarDriver()
            {
                DriverId = 3,
                DriverName = "Austin Dillon"
            });
            items.Add(new NascarDriver()
            {
                DriverId = 4,
                DriverName = "Jeb Burton"
            });

            items.Add(new NascarDriver()
            {
                DriverId = 5,
                DriverName = "Cole Whitt"
            });
            items.Add(new NascarDriver()
            {
                DriverId = 6,
                DriverName = "Jeb Burton"
            });

            items.Add(new NascarDriver()
            {
                DriverId = 7,
                DriverName = "Jeb Burton"
            });

            items.Add(new NascarDriver()
            {
                DriverId = 8,
                DriverName = "Daniel Hemrick"
            });
            items.Add(new NascarDriver()
            {
                DriverId = 9,
                DriverName = "Chase Elliott"
            });

            items.Add(new NascarDriver()
            {
                DriverId = 10,
                DriverName = "Aric Almirola"
            });

            for (int i = 11; i < 99; i++)
            {
                items.Add(new NascarDriver()
                {
                    DriverId = i,
                    DriverName = $"Driver {i}"
                });
            }

            return items;
        }
    }
}
