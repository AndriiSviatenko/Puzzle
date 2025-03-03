using _Project.Scripts.Infractructure.CoroutineRunner;
using _Project.Scripts.Infractructure.Patterns.EntryPoint;
using _Project.Scripts.Services.ClickDetection;
using _Project.Scripts.Services.Grid;
using _Project.Scripts.Services.Input;
using _Project.Scripts.Services.PathValidator;
using _Project.Scripts.Services.Spawner;
using _Project.Scripts.Services.Timer;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infractructure.Installers.Scene.Mono.Services
{
    public class Services : MonoInstaller
    {
        [SerializeField] private CoroutineRunner.CoroutineRunner prefab;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<ClickDetection>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner.CoroutineRunner>()
                .FromComponentInNewPrefab(prefab)
                .AsSingle();

            Container
                .Bind<Timer>()
                .AsSingle();
            Container
                .Bind<PathValidator>()
                .AsSingle();

            Container
                .Bind<PuzzleGrid>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<EntryPoint>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<Game.Game>()
                .AsSingle();

            Container
                .Bind<Spawner>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<InputProvider>()
                .AsSingle();

#if UNITY_EDITOR
            Container
                .BindInterfacesAndSelfTo<Cheats.Cheats>()
                .AsSingle();
#endif
        }
    }
}
