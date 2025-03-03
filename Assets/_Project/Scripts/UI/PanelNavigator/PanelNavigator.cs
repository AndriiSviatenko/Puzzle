using _Project.Scripts.UI.Base;
using _Project.Scripts.UI.Repository;

namespace _Project.Scripts.UI.PanelNavigator
{
    public class PanelNavigator
    {
        private RechangerPanel _rechangerPanel;
        private UIRepository _uiRepository;

        public PanelNavigator(RechangerPanel rechangerPanel, UIRepository uiRepository)
        {
            _rechangerPanel = rechangerPanel;
            _uiRepository = uiRepository;
            InitPanels();
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            ShowCheatPanel();
#endif
        }

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        private void ShowCheatPanel()
        {
            _uiRepository.Cheat.Show();
        }
#endif

        private void InitPanels()
        {
            _uiRepository.Lose.Subscribes();
        }

        public void ShowGame() => 
            _rechangerPanel.ShowPanel(_uiRepository.Game);

        public void ShowWin() => 
            _rechangerPanel.ShowPanel(_uiRepository.Win);

        public void ShowLose() => 
            _rechangerPanel.ShowPanel(_uiRepository.Lose);

        public void ShowLoading() => 
            _rechangerPanel.ShowPanel(_uiRepository.Loading);
    }
}
