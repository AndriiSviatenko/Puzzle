using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.UI.Base
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BasePanel : MonoBehaviour
    {
        private const int SHOW_END_VALUE = 1;
        private const int HIDE_END_VALUE = 0;

        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float duration = 0.2f;
        
        public virtual void Show()
        {
            canvasGroup.DOFade(SHOW_END_VALUE, duration);
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            canvasGroup.ignoreParentGroups = true;
        }
        public void Hide()
        {
            canvasGroup.DOFade(HIDE_END_VALUE, duration);
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvasGroup.ignoreParentGroups = false;
        }
    }
}
