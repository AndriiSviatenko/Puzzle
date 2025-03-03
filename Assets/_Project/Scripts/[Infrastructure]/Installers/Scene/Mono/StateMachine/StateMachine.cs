using _Project.Scripts.Infractructure.Patterns.Factory.StateMachine;
using Zenject;

namespace _Project.Scripts.Infractructure.Installers.Scene.Mono.StateMachine
{
    public class StateMachine : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactory();
        }
        private void BindFactory()
        {
            Container
                .Bind<StateMachineFactory>()
                .AsSingle();
        }
    }
}
