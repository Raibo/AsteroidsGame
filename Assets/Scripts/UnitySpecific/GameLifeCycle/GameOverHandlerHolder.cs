using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific
{
    public class GameOverHandlerHolder : EntityHolder<IGameOverHandler>
    {
        public EntityHolder<INewGameHandler> NewGameHandler;
        public EntityHolder<IGameStateHandler> GameStateHandler;

        public override IGameOverHandler Entity => _gameOverHandler;

        private IGameOverHandler _gameOverHandler;


        public void Awake()
        {
            _gameOverHandler = new GameOverHandler(GameStateHandler.Entity);
            _gameOverHandler.GameOverDeclared += OnGameOver;
        }


        private void OnGameOver() =>
            NewGameHandler.gameObject.SetActive(true);


        private void OnDestroy() =>
            _gameOverHandler.GameOverDeclared -= OnGameOver;
    }
}
