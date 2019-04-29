using System.Collections.Generic;
using NascarApi.Simulation.Adapters;

namespace NascarApi.Simulation.Internal.Factories
{
    abstract class Factory<T, Key> where T : IKeyedItem<Key>, new()
    {
        public abstract IList<T> GetList();
    }
}
