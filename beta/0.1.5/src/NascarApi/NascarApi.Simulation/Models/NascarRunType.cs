using System;

namespace NascarApi.Mock.Models
{
    [Flags()]
    public enum NascarRunType
    {
        Practice1 = 1,
        Practice2 = 3,
        FinalPractice = 4,
        Practice = Practice1 | Practice2 | FinalPractice,
        QualifyingStage1 = 8,
        QualifyingStage2 = 16,
        FinalQualifyingStage = 32,
        Qualifying = QualifyingStage1 | QualifyingStage2 | FinalQualifyingStage,
        RaceStage1 = 64,
        RaceStage2 = 128,
        FinalRaceStage = 256,
        Race = RaceStage1 | RaceStage2 | FinalRaceStage,
        CupRuns = Practice | Qualifying | Race,
        XFinityRuns = Practice1 | Practice2 | QualifyingStage2 | FinalQualifyingStage | Race,
        TruckRuns = Practice1 | Practice2 | QualifyingStage2 | FinalQualifyingStage | Race,
        BaseRunTypes = Practice1 | Practice2 | FinalPractice | QualifyingStage1 | QualifyingStage2 | FinalQualifyingStage | RaceStage1 | RaceStage2 | FinalRaceStage
    }
}
