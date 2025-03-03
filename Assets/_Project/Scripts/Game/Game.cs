using _Project.Scripts.Game.GameSettings.Config;
using _Project.Scripts.Infractructure.CoroutineRunner;
using _Project.Scripts.Puzzles;
using _Project.Scripts.Services.ClickDetection;
using _Project.Scripts.Services.Spawner;
using _Project.Scripts.Services.Timer;
using System;
using System.Linq;

namespace _Project.Scripts.Game
{
    public class Game
    {
        public event Action WinEvent;
        public event Action LoseEvent;

        private readonly UI.Panels.Game.Timer.Timer _uiTimer;
        private readonly Spawner _spawner;
        private readonly Timer _timer;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ClickDetection _clickService;
        private readonly float _timeLimit;

        public Game(Config config, UI.Panels.Game.Timer.Timer uiTimer, Spawner spawner, Services.Timer.Timer timer, ICoroutineRunner coroutineRunner, ClickDetection clickService)
        {
            _timeLimit = config.TimeLimit;
            _uiTimer = uiTimer;
            _spawner = spawner;
            _timer = timer;
            _coroutineRunner = coroutineRunner;
            _clickService = clickService;
        }

        public void Initialize()
        {
            _timer.Set(_timeLimit);
            _timer.HasBeenUpdated += _uiTimer.UpdateTimer;
            _timer.TimeIsOver += Lose;
            _uiTimer.UpdateTimer(_timeLimit);
            _timer.StartCountingTime(_coroutineRunner.StartCoroutine);
            _clickService.OnClickEvent += CheckWin;
        }
        public void UnSubscribe()
        {
            _timer.TimeIsOver -= Lose;
            _timer.HasBeenUpdated -= _uiTimer.UpdateTimer;
            _clickService.OnClickEvent -= CheckWin;
            _timer.StopCountingTime(_coroutineRunner.StopCoroutine);
        }

        private void CheckWin(PuzzleElement element)
        {
            if (_spawner.StartElement != null)
            {
                if (_spawner.StartElement.IsConnectedToPath)
                {
                    if (_spawner.EndElements.All(endElement => endElement.IsConnectedToPath))
                    {
                        Win();
                    }
                }
            }
        }

        private void Win()
        {
            WinEvent?.Invoke();
            UnSubscribe();
        }
        private void Lose()
        {
            LoseEvent?.Invoke();
            UnSubscribe();
        }
    }
}
