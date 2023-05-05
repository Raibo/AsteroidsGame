using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics
{
    public class Timer : ITimer
    {
        public float RemainingTime { get; private set; }
        public bool IsFinished => RemainingTime <= 0;


        public void StartCountdown(float remainingTime) =>
            RemainingTime = remainingTime;


        public void Update(float time)
        {
            RemainingTime -= time;
            RemainingTime = MathF.Max(0f, RemainingTime);
        }
    }
}
