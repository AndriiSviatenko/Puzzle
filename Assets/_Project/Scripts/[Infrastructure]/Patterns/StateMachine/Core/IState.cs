namespace _project.Scripts.Infrastructure.Patterns.StateMachine.Core
{  
    public interface IState : IExitableState
    {
        void Enter();
    }
}