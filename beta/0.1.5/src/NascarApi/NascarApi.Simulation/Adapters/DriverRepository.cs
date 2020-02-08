using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Mock.Internal.Factories;
using NascarApi.Mock.Models;
using NascarApi.Mock.Ports;

namespace NascarApi.Mock.Adapters
{
    class DriverRepository : JsonRepository<NascarDriver, int>, IDriverRepository
    {
        #region fields

        private readonly DriverFactory _factory;

        #endregion

        #region ctor

        public DriverRepository()
            : base("drivers.json")
        {
            _factory = new DriverFactory();
            if (_items.Count == 0)
            {
                var items = _factory.GetList();
                foreach (var item in items)
                {
                    base.Insert(item);
                }
            }
        }

        #endregion

        #region public

        public virtual async Task<NascarDriver> GetAsync(int id)
        {
            return await Task.FromResult(base.Get(id));
        }

        public virtual async Task<IEnumerable<NascarDriver>> GetListAsync()
        {
            return await Task.FromResult(base.GetList());
        }

        public virtual async Task<NascarDriver> SaveAsync(NascarDriver item)
        {
            if (item.DriverId <= 0)
            {
                item.DriverId = base.GetLastId() + 1;
                return await Task.FromResult(base.Insert(item));
            }
            else
            {
                return await Task.FromResult(base.Update(item));
            }
        }

        #endregion
    }
}
