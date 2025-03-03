using TMPro;

namespace _Project.Scripts.UI.Panels.Game.Timer
{
    public class Timer
    {
        private TextMeshProUGUI _timerText;

        public Timer(TextMeshProUGUI timerText) =>
            _timerText = timerText;

        public void UpdateTimer(float timeRemaining) =>
            _timerText.text = timeRemaining.ToString("F2");
    }
}