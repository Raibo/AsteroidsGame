using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters
{
    public class ScoreCounterHolder : MonoBehaviour
    {
        public IScoreCounter ScoreCounter => GetScoreCounter();

        private IScoreCounter _scoreCounter;


        private IScoreCounter GetScoreCounter()
        {
            _scoreCounter ??= new ScoreCounter();
            return _scoreCounter;
        }
    }
}
