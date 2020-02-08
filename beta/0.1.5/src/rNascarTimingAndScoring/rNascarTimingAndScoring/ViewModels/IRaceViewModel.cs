using System.ComponentModel;
using System.Threading.Tasks;
using NascarApi.Models;
using rNascarTimingAndScoring.Models;

namespace rNascarTimingAndScoring.ViewModels
{
    public interface IRaceViewModel
    {
        TSConfiguration Configuration { get; set; }
        EventSettings EventSettings { get; set; }
        BindingList<TSGridRowModel> BiggestMoverModels { get; set; }
        BindingList<TSGridRowModel> FastestLapModels { get; set; }
        BindingList<TSGridRowModel> LapLeaderModels { get; set; }
        BindingList<TSDriverModel> LeaderboardModels { get; set; }
        BindingList<TSGridRowModel> OffThePaceModels { get; set; }
        BindingList<TSGridRowModel> PointStandingsModels { get; set; }
        BindingList<TSGridRowModel> TenLapAverageModels { get; set; }

        Task UpdateFeedDataAsync();
    }
}