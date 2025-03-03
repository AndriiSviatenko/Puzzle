using _Project.Scripts.UI.Base;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI.Panels.Game
{
    public class Game : BasePanel
    {
        [SerializeField] private TextMeshProUGUI time;
        public TextMeshProUGUI Time => time;
    }
}
