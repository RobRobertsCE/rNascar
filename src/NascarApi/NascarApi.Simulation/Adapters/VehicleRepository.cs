using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Mock.Internal.Factories;
using NascarApi.Mock.Models;
using NascarApi.Mock.Ports;

namespace NascarApi.Mock.Adapters
{
    class VehicleRepository : JsonRepository<NascarVehicle, int>, IVehicleRepository
    {
        #region fields

        private readonly VehicleFactory _factory;

        #endregion

        #region ctor

        public VehicleRepository()
            : base("vehicles.json")
        {
            _factory = new VehicleFactory();
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

        public virtual async Task<NascarVehicle> GetAsync(int id)
        {
            return await Task.FromResult(base.Get(id));
        }

        public virtual async Task<IEnumerable<NascarVehicle>> GetListAsync()
        {
            return await Task.FromResult(base.GetList());
        }

        public virtual async Task<NascarVehicle> SaveAsync(NascarVehicle item)
        {
            if (item.VehicleId  <= 0)
            {
                item.VehicleId = base.GetLastId() + 1;
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