using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Mock.Internal.Factories;
using NascarApi.Mock.Models;
using NascarApi.Mock.Ports;
using System.Linq;

namespace NascarApi.Mock.Adapters
{
    class SeriesRepository : JsonRepository<NascarSeries, int>, ISeriesRepository
    {
        #region fields

        private readonly SeriesFactory _factory;

        #endregion

        #region ctor

        public SeriesRepository()
            : base("series.json")
        {
            _factory = new SeriesFactory();
            if (_items.Count == 0)
            {
                var items =  _factory.GetList();
                foreach (var item in items)
                {
                    base.Insert(item);
                }
            }
        }

        #endregion

        #region public

        public virtual async Task<NascarSeries> GetAsync(int id)
        {
            return await Task.FromResult(base.Get(id));
        }

        public virtual async Task<IEnumerable<NascarSeries>> GetListAsync()
        {
            return await Task.FromResult(base.GetList());
        }

        public virtual async Task<NascarSeries> SaveAsync(NascarSeries item)
        {
            if (item.SeriesId <= 0)
            {
                item.SeriesId = base.GetLastId() + 1;
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
