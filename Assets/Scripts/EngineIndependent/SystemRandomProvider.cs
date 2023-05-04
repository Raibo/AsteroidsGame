using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent
{
    public class SystemRandomProvider : IRandomProvider
    {
        private Random _random;


        public SystemRandomProvider() =>
            _random = new Random();


        public float Next(float minimumInclusive, float maximumExclusive)
        {
            if (maximumExclusive < minimumInclusive)
                (minimumInclusive, maximumExclusive) = (maximumExclusive, minimumInclusive);

            var range = maximumExclusive - minimumInclusive;

            return (float)_random.NextDouble() * range + minimumInclusive;
        }
    }
}
