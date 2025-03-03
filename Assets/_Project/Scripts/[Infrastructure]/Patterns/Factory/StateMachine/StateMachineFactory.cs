using _project.Scripts.Infrastructure.Patterns.StateMachine.Core;
using _project.Scripts.Infrastructure.Patterns.StateMachine.Implementation;
using _Project.Scripts.Infractructure.CoroutineRunner;
using _Project.Scripts.Services.Input;
using _Project.Scripts.Services.Spawner;
using _Project.Scripts.UI;
using _Project.Scripts.UI.PanelNavigator;
using _Project.Scripts.UI.Repository;
using System;
using System.Collections.Generic;
using Zenject;

namespace _Project.Scripts.Infractructure.Patterns.Factory.StateMachine
{
    public class StateMachineFactory
    {
        private readonly DiContainer _container;

        private PanelNavigator _panelNavigator;
        private Spawner _spawner;
        private Game.Game _game;
        private InputProvider _inputProvider;
        private ICoroutineRunner _coroutineRunner;
        private UIRepository _uiRepository;

        public StateMachineFactory(DiContainer container) =>
            _container = container;

        public _project.Scripts.Infrastructure.Patterns.StateMachine.Core.StateMachine Create()
        {
            var stateMachine = new _project.Scripts.Infrastructure.Patterns.StateMachine.Core.StateMachine();

            ResolveDependencies();

            var states = CreateStates(stateMachine);
            stateMachine.SetStates(states);

            BindInstanceStateMachine(stateMachine);
            return stateMachine;
        }

        private void BindInstanceStateMachine(_project.Scripts.Infrastructure.Patterns.StateMachine.Core.StateMachine stateMachine)
        {
            _container
                .BindInterfacesAndSelfTo<_project.Scripts.Infrastructure.Patterns.StateMachine.Core.StateMachine>()
                .FromInstance(stateMachine)
                .AsSingle();
        }

        private Dictionary<Type, IExitableState> CreateStates(_project.Scripts.Infrastructure.Patterns.StateMachine.Core.StateMachine stateMachine)
        {
            var _startState = new StartState(stateMachine, _inputProvider, _panelNavigator, _spawner, _game, _coroutineRunner);
            var _gameLoop = new GameLoop(stateMachine, _game);
            var _win = new Win(stateMachine, _inputProvider, _panelNavigator);
            var _lose = new Lose(stateMachine, _inputProvider, _panelNavigator, _uiRepository);

            var states = new Dictionary<Type, IExitableState>()
            {
                {typeof(StartState), _startState},
                {typeof(GameLoop), _gameLoop},
                {typeof(Win), _win},
                {typeof(Lose), _lose},
            };
            return states;
        }
        private void ResolveDependencies()
        {
            _panelNavigator = _container.Resolve<PanelNavigator>();
            _spawner = _container.Resolve<Spawner>();
            _game = _container.Resolve<Game.Game>();
            _uiRepository = _container.Resolve<UIRepository>();
            _coroutineRunner = _container.Resolve<ICoroutineRunner>();
            _inputProvider = _container.Resolve<InputProvider>();
        }
    }
}
