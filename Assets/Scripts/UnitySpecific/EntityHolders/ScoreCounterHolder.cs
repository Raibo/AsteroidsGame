using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameEntities;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.EntityHolders
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
