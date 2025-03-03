using _project.Scripts.Infrastructure.Patterns.StateMachine.Core;
using _Project.Scripts.Services.Input;
using _Project.Scripts.UI.PanelNavigator;

namespace _project.Scripts.Infrastructure.Patterns.StateMachine.Implementation
{
    public class Win : IState
    {
        private Core.StateMachine _stateMachine;
        private readonly InputProvider _inputProvider;
        private PanelNavigator _panelNavigator;

        public Win(Core.StateMachine stateMachine, InputProvider inputProvider, PanelNavigator panelNavigator)
        {
            _stateMachine = stateMachine;
            _inputProvider = inputProvider;
            _panelNavigator = panelNavigator;
        }

        public void Enter()
        {
            _panelNavigator.ShowWin();
            _inputProvider.Disable();
        }

        public void Exit() { }
    }
}
