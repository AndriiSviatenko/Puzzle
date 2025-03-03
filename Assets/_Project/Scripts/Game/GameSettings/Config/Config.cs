using UnityEngine;

namespace _Project.Scripts.Game.GameSettings.Config
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Configs/GameSettings")]
    public class Config : ScriptableObject
    {
        [field: SerializeField] public float TimeLimit { get; private set; }
    }
}