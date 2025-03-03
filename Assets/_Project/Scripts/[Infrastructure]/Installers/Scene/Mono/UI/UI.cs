using _Project.Scripts.UI.Base;
using _Project.Scripts.UI.PanelNavigator;
using _Project.Scripts.UI.Panels.Game.Timer;
using _Project.Scripts.UI.Panels.Loading;
using _Project.Scripts.UI.Panels.Lose;
using _Project.Scripts.UI.Panels.Win;
using _Project.Scripts.UI.Repository;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infractructure.Installers.Scene.Mono.UI
{
    public class UI : MonoInstaller
    {
        [SerializeField] private Loading loading;
        [SerializeField] private Scripts.UI.Panels.Game.Game game;
        [SerializeField] private Win win;
        [SerializeField] private Lose lose;
        [SerializeField] private BasePanel cheats;

        public override void InstallBindings()
        {
            var uiRepository = new UIRepository();
            uiRepository.Add(loading);
            uiRepository.Add(game);
            uiRepository.Add(win);
            uiRepository.Add(lose);

#if UNITY_EDITOR
            uiRepository.Add(cheats);
#endif

            Container
                .Bind<UIRepository>()
                .FromInstance(uiRepository)
                .AsSingle();

            Container
                .Bind<RechangerPanel>()
                .AsSingle();

            Container
                .Bind<PanelNavigator>()
                .AsSingle();
            Container
                .Bind<Timer>()
                .AsSingle()
                .WithArguments(game.Time);
        }
    }

}
