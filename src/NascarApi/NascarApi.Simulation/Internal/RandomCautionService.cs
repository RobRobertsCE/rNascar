using System;
using NascarApi.Simulation.Internal.Models;

namespace NascarApi.Simulation.Internal
{
    class RandomCautionService
    {
        #region fields

        Random _cautionGenerator = new Random(DateTime.Now.Millisecond);
        int _cautionGeneratorMax = 1000;
        int _randomCautionThreshold = 52;
        int _randomCautionLapMin = 5;
        int _randomCautionLapMax = 8;

        #endregion

        #region public

        public RandomCautionResult GetRandomCautionResult()
        {
            var random = GetRandomCaution();

            return new RandomCautionResult()
            {
                IsCaution = (random > 0),
                CautionLaps = random
            };
        }

        #endregion

        #region protected

        protected virtual int GetRandomCaution()
        {
            if (RandomCautionGenerator())
                return RandomCautionLapsGenerator();
            else
                return 0;
        }

        protected virtual bool RandomCautionGenerator()
        {
            var randomValue = _cautionGenerator.Next(0, _cautionGeneratorMax);
            return (randomValue <= _randomCautionThreshold);
        }

        protected virtual int RandomCautionLapsGenerator()
        {
            return _cautionGenerator.Next(_randomCautionLapMin, _randomCautionLapMax);
        }

        #endregion
    }
}
