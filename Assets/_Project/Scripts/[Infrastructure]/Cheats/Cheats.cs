using _project.Scripts.Infrastructure.Patterns.StateMachine.Core;
using _project.Scripts.Infrastructure.Patterns.StateMachine.Implementation;
using UnityEngine;
using Zenject;

#if UNITY_EDITOR
namespace _Project.Scripts.Infractructure.Cheats
{
    public class Cheats : ITickable
    {
        private StateMachine _stateMachine;

        public void SetStateMachine(StateMachine stateMachine) =>
            _stateMachine = stateMachine;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _stateMachine.Enter<StartState>();
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                _stateMachine.Enter<Lose>();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                _stateMachine.Enter<Win>();
            }
        }
    }

}
#endif