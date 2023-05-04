namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent
{
    public interface IRandomProvider
    {
        public float Next(float minimumInclusive, float maximumExclusive);
    }
}
