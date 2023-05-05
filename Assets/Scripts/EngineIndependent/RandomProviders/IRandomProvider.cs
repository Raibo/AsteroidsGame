namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.RandomProviders
{
    public interface IRandomProvider
    {
        public float Next(float minimumInclusive, float maximumExclusive);
    }
}
