using _project.Scripts.Infrastructure.Patterns.StateMachine.Core;
using _project.Scripts.Infrastructure.Patterns.StateMachine.Implementation;
using _Project.Scripts.Infractructure.Patterns.Factory.StateMachine;
using _Project.Scripts.UI.PanelNavigator;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infractructure.Patterns.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        private PanelNavigator _panelNavigator;
        private StateMachine _stateMachine;

#if UNITY_EDITOR
        [Inject] private Cheats.Cheats _cheats;
#endif

        [Inject]
        private void Construct(PanelNavigator panelNavigator, StateMachineFactory stateMachineFactory)
        {
            _panelNavigator = panelNavigator;
            _stateMachine = stateMachineFactory.Create();
#if UNITY_EDITOR
            _cheats.SetStateMachine(_stateMachine);
#endif
        }

        private void Awake()
        {
            _panelNavigator.ShowLoading();
            _stateMachine.Enter<StartState>();
        }
    }
}
