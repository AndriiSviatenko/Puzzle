namespace _project.Scripts.Infrastructure.Patterns.StateMachine.Core
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}