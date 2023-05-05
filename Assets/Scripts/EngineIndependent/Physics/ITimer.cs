namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics
{
    public interface ITimer
    {
        public float RemainingTime { get; }
        public bool IsFinished { get; }
        public void StartCountdown(float remainingTime);
        public void Update(float time);
    }
}
