using _project.Scripts.Infrastructure.Patterns.StateMachine.Core;
using _Project.Scripts.Game;

namespace _project.Scripts.Infrastructure.Patterns.StateMachine.Implementation
{
    public class GameLoop : IState
    {
        private Core.StateMachine _stateMachine;
        private Game _game;

        public GameLoop(Core.StateMachine stateMachine, Game game)
        {
            _stateMachine = stateMachine;
            _game = game;
        }

        public void Enter()
        {
            _game.WinEvent += OnWin;
            _game.LoseEvent += OnLose;
        }

        private void OnLose() => 
            _stateMachine.Enter<Lose>();

        private void OnWin() => 
            _stateMachine.Enter<Win>();

        public void Exit()
        {
            _game.WinEvent -= OnWin;
            _game.LoseEvent -= OnLose;
        }
    }
}