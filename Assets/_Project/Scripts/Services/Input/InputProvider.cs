namespace _Project.Scripts.Services.Input
{
    public class InputProvider
    {
        private bool _isEnable;

        public void Enable() =>
            _isEnable = true;
        public void Disable() =>
            _isEnable = false;

        public bool GetClickMouseDown(int button)
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            if (_isEnable)
                return UnityEngine.Input.GetMouseButtonDown(button);
#elif UNITY_IOS || UNITY_ANDROID
            if(_isEnable)
                return UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began;
#endif
            return false;
        }
    }

}
