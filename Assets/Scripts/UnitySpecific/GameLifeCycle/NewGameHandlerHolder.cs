using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons;
using UnityEngine.UI;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.GameLifeCycle
{
    public class NewGameHandlerHolder : EntityHolder<INewGameHandler>
    {
        public EntityHolder<IGameStateHandler> GameStateHandler;
        public EntityHolder<IEnemiesCounter> EnemiesCounter;
        public EntityHolder<IPhysicsObject> ShipObject;
        public EntityHolder<IAmmoProvider> ShipLaserAmmo;
        public EntityHolder<IScoreCounter> ScoreCounter;
        public EntityHolder<IUiInputProvider> UiInputProvider;
        public Text NewGameProposal;

        public override INewGameHandler Entity => throw new System.NotImplementedException();

        private INewGameHandler _entity;


        private void Awake()
        {
            _entity = new NewGameHandler(GameStateHandler.Entity, EnemiesCounter.Entity, ShipObject.Entity, ShipLaserAmmo.Entity,
                ScoreCounter.Entity);

            _entity.NewGameStarted += SelfDisable;
        }


        private void OnEnable() =>
            NewGameProposal.text = $"Game Over\nScore: {ScoreCounter.Entity.CurrentScore}\nPress 'N' to start a New Game";


        private void Update()
        {
            if (UiInputProvider.Entity.IsNewGameRequested)
                _entity.StartNewGame();
        }


        private void SelfDisable() =>
            gameObject.SetActive(false);


        private void OnDestroy() =>
            _entity.NewGameStarted -= SelfDisable;
    }
}
