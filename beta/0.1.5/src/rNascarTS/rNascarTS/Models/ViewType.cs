using System;

namespace rNascarTS.Models
{
    [Flags()]
    public enum ViewType
    {
        List = 1,
        Leaderboard = 2,
        Graph = 4,
        Application = 8,
        All = List | Leaderboard | Graph | Application
    }
}
