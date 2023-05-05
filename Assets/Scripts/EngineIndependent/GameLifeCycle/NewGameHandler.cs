using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle
{
    public class NewGameHandler : INewGameHandler
    {
        public event Action NewGameStarted;

        private readonly IGameStateHandler _gameStateHandler;
        private readonly IEnemiesCounter _enemiesCounter;
        private readonly IPhysicsObject _shipObject;
        private readonly IAmmoProvider _laserAmmo;
        private readonly IScoreCounter _scoreCounter;

        private readonly Vector2 _initialShipPosition = new(0f, 0f);
        private readonly Vector2 _initialShipVelocity = new(0f, 0f);
        private readonly float _initialShipRotation = 0f;


        public NewGameHandler(IGameStateHandler gameStateHandler, IEnemiesCounter enemiesCounter, IPhysicsObject shipObject,
            IAmmoProvider laserAmmo, IScoreCounter scoreCounter)
        {
            _gameStateHandler = gameStateHandler;
            _enemiesCounter = enemiesCounter;
            _shipObject = shipObject;
            _laserAmmo = laserAmmo;
            _scoreCounter = scoreCounter;
        }


        public void StartNewGame()
        {
            _enemiesCounter.DestroyCountedEnemies();

            _shipObject.Position = _initialShipPosition;
            _shipObject.Velocity = _initialShipVelocity;
            _shipObject.Rotation = _initialShipRotation;

            _laserAmmo.Reset();
            _scoreCounter.Reset();

            _gameStateHandler.GameState = GameState.Running;
            _gameStateHandler.Unpause();

            NewGameStarted?.Invoke();
        }
    }
}
