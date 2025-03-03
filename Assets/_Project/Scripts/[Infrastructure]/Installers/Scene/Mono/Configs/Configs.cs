using _Project.Scripts.Game.GameSettings.Config;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infractructure.Installers.Scene.Mono.Configs
{
    public class Configs : MonoInstaller
    {
        [SerializeField] private Config gameSettings;
        public override void InstallBindings()
        {
            Container
                .Bind<Config>()
                .FromScriptableObject(gameSettings)
                .AsSingle();
        }
    }
}