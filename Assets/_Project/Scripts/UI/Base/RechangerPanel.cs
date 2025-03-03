using System;

namespace _Project.Scripts.UI.Base
{
    public class RechangerPanel
    {
        private BasePanel _panel;
        
        public void ShowPanel(BasePanel panel)
        {
            if (panel == null)
                throw new ArgumentException(nameof(panel));
            
            _panel?.Hide();
            _panel = panel;
            _panel.Show();
        }
    }
}
