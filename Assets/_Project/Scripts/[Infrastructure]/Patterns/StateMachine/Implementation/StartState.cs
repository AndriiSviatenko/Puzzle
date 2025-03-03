using _Project.Scripts.Infractructure.CoroutineRunner;
using _Project.Scripts.Game;
using System.Collections;
using _project.Scripts.Infrastructure.Patterns.StateMachine.Core;
using _Project.Scripts.Services.Input;
using _Project.Scripts.Services.Spawner;
using _Project.Scripts.UI.PanelNavigator;

namespace _project.Scripts.Infrastructure.Patterns.StateMachine.Implementation
{
    public class StartState : IState
    {
        private readonly Core.StateMachine _stateMachine;
        private readonly InputProvider _inputProvider;
        private readonly PanelNavigator _panelNavigator;
        private readonly Spawner _spawner;
        private readonly Game _game;
        private readonly ICoroutineRunner _coroutineRunner;

        public StartState(Core.StateMachine stateMachine, InputProvider inputProvider, PanelNavigator panelNavigator, Spawner spawner, Game game, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _inputProvider = inputProvider;
            _panelNavigator = panelNavigator;
            _spawner = spawner;
            _game = game;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _coroutineRunner.StartCoroutine(SpawnerRoutine());
        }
        private IEnumerator SpawnerRoutine()
        {
            yield return _spawner.ClearPuzzle();
            yield return _spawner.StartSpawn();

            _game.Initialize();
            _inputProvider.Enable();
            _panelNavigator.ShowGame();
            _stateMachine.Enter<GameLoop>();
        }

        public void Exit() { }
    }
}
