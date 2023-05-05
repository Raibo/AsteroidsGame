using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.RandomProviders;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation
{
    public class EnemySpawner
    {
        private readonly IObjectFactory _enemiesFactory;
        private readonly IEnemiesCounter _enemiesCounter;
        private readonly IRandomProvider _randomProvider;
        private readonly Vector2 _origin;
        private readonly float _minimumInterval;
        private readonly float _maximumInterval;
        private readonly int _enemiesCountLimit;

        private float _timeBeforeNextAttempt;


        public EnemySpawner(IObjectFactory enemiesFactory, IEnemiesCounter enemiesCounter, IRandomProvider randomProvider,
            Vector2 origin, float minimumInterval, float MaximumInterval, int enemiesCountLimit)
        {
            _enemiesFactory = enemiesFactory;
            _enemiesCounter = enemiesCounter;
            _randomProvider = randomProvider;
            _origin = origin;
            _minimumInterval = minimumInterval;
            _maximumInterval = MaximumInterval;
            _enemiesCountLimit = enemiesCountLimit;

            _timeBeforeNextAttempt = GetNextAttemptTime();
        }


        public void Update(float time)
        {
            _timeBeforeNextAttempt -= time;

            if (_timeBeforeNextAttempt > 0)
                return;

            _timeBeforeNextAttempt = GetNextAttemptTime();
            AttemptToSpawnEnemy();
        }


        private void AttemptToSpawnEnemy()
        {
            if (_enemiesCounter.Count >= _enemiesCountLimit)
                return;

            _enemiesFactory.Create(_origin, Vector2.Zero, 0f);
        }


        private float GetNextAttemptTime() =>
            _randomProvider.Next(_minimumInterval, _maximumInterval);
    }
}
