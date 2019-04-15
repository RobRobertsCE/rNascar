using System.Collections.Generic;
using NascarApi.Mock.Adapters;

namespace NascarApi.Mock.Internal.Factories
{
    abstract class Factory<T, Key> where T : IKeyedItem<Key>, new()
    {
        public abstract IList<T> GetList();
    }
}
