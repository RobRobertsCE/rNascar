using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Mock.Internal.Factories;
using NascarApi.Mock.Models;
using NascarApi.Mock.Ports;

namespace NascarApi.Mock.Adapters
{
    class TrackRepository : JsonRepository<NascarTrack, int>, ITrackRepository
    {
        #region fields

        private readonly TrackFactory _factory;

        #endregion

        #region ctor

        public TrackRepository()
            : base("tracks.json")
        {
            _factory = new TrackFactory();
            if (_items.Count==0)
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

        public virtual async Task<NascarTrack> GetAsync(int id)
        {
            return await Task.FromResult(base.Get(id));
        }

        public virtual async Task<IEnumerable<NascarTrack>> GetListAsync()
        {
            return await Task.FromResult(base.GetList());
        }

        public virtual async Task<NascarTrack> SaveAsync(NascarTrack item)
        {
            if (item.TrackId <= 0)
            {
                item.TrackId = base.GetLastId() + 1;
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
