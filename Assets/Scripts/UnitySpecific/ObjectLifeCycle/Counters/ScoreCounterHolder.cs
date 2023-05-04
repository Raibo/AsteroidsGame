using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters
{
    public class ScoreCounterHolder : EntityHolder<IScoreCounter>
    {
        public override IScoreCounter Entity => GetScoreCounter();

        private IScoreCounter _scoreCounter;


        private IScoreCounter GetScoreCounter()
        {
            _scoreCounter ??= new ScoreCounter();
            return _scoreCounter;
        }
    }
}
