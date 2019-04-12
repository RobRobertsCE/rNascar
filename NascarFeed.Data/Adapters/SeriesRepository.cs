using System.Collections.Generic;
using System.Linq;
using NascarFeed.Data.Models;
using NascarFeed.Data.Ports;

namespace NascarFeed.Data.Adapters
{
    class SeriesRepository : ISeriesRepository
    {
        private List<SeriesModel> _series = new List<SeriesModel>();

        public SeriesRepository()
        {

        }

        public SeriesModel Get(int id)
        {
            return _series.FirstOrDefault(e => e.id == id);
        }

        public IList<SeriesModel> GetList()
        {
            return _series;
        }
    }
}
