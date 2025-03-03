using _project.Scripts.Infrastructure.Patterns.StateMachine.Core;
using _Project.Scripts.Services.Input;
using _Project.Scripts.UI.PanelNavigator;
using _Project.Scripts.UI.Repository;

namespace _project.Scripts.Infrastructure.Patterns.StateMachine.Implementation
{
    public class Lose : IState
    {
        private readonly Core.StateMachine _stateMachine;
        private readonly InputProvider _inputProvider;
        private readonly PanelNavigator _panelNavigator;
        private readonly UIRepository _uiRepository;

        public Lose(Core.StateMachine stateMachine, InputProvider inputProvider, PanelNavigator panelNavigator, UIRepository uiRepository)
        {
            _stateMachine = stateMachine;
            _inputProvider = inputProvider;
            _panelNavigator = panelNavigator;
            _uiRepository = uiRepository;
        }

        public void Enter()
        {
            _panelNavigator.ShowLose();
            _inputProvider.Disable();
            _uiRepository.Lose.RestartEvent += OnRestart;
        }
        public void Exit() => 
            _uiRepository.Lose.RestartEvent -= OnRestart;

        private void OnRestart() => 
            _stateMachine.Enter<StartState>();
    }
}
