using _Project.Scripts.UI.Base;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Panels.Lose
{
    public class Lose : BasePanel
    {
        public event Action RestartEvent;

        [SerializeField] private Button restartBtn;

        public void Subscribes() => 
            restartBtn.onClick.AddListener(OnRestart);

        public void UnSubscribes() =>
            restartBtn.onClick.RemoveListener(OnRestart);

        private void OnRestart() => 
            RestartEvent?.Invoke();
    }
}