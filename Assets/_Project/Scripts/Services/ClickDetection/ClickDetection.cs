using _Project.Scripts.Puzzles;
using _Project.Scripts.Services.Input;
using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Services.ClickDetection
{
    public class ClickDetection : MonoBehaviour, ITickable
    {
        private const int MAX_DISTANCE_DETECT = 10;
        public event Action<PuzzleElement> OnClickEvent;

        [SerializeField] private LayerMask layerMask;
        private InputProvider _inputProvider;

        [Inject]
        private void Constructor(InputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }
        public void Tick()
        {
            if (_inputProvider.GetClickMouseDown(0))
                DetectObjectUnderCursor();
        }

        private void DetectObjectUnderCursor()
        {
            Ray ray;
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
#elif UNITY_IOS || UNITY_ANDROID
            ray = Camera.main.ScreenPointToRay(UnityEngine.Input.GetTouch(0).position);
#endif
            if (Physics.Raycast(ray, out RaycastHit hit, MAX_DISTANCE_DETECT, layerMask))
            {
                if (hit.collider.TryGetComponent(out PuzzleElement puzzleElement))
                {
                    puzzleElement.RotateElement();
                    OnClickEvent?.Invoke(puzzleElement);
                }
            }
        }
    }

}
