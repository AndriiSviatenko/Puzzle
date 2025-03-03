using _Project.Scripts.UI.Base;
using _Project.Scripts.UI.Panels.Cheat;
using _Project.Scripts.UI.Panels.Loading;
using System.Collections.Generic;

namespace _Project.Scripts.UI.Repository
{
    public class UIRepository
    {
        private List<BasePanel> _allPanels = new();
        public List<BasePanel> AllPanels => _allPanels;

        public Panels.Game.Game Game { get; private set; }
        public Panels.Win.Win Win { get; private set; }
        public Panels.Lose.Lose Lose { get; private set; }
        public Loading Loading { get; private set; }

#if UNITY_EDITOR
        public Cheat Cheat { get; private set; }
#endif


        public void Add(BasePanel panel)
        {
            _allPanels.Add(panel);

            if(panel is Panels.Game.Game gamePanel)
            {
                Game = gamePanel;
            }
            else if (panel is Panels.Win.Win winPanel)
            {
                Win = winPanel;
            }
            else if (panel is Panels.Lose.Lose losePanel)
            {
                Lose = losePanel;
            }
            else if (panel is Loading loading)
            {
                Loading = loading;
            }
#if UNITY_EDITOR
            else if (panel is Cheat cheat)
            {
                Cheat = cheat;
            }
#endif
        }
    }
}