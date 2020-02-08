using System.Collections.Generic;
using System.Linq;
using NascarApi.Data.Models;
using NascarApi.Data.Ports;

namespace NascarApi.Data.Adapters
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
