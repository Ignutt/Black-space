using System;
using UnityEngine;

namespace Common
{
    public delegate void OnTouch(SideType sideType);

    public enum SideType
    {
        Left,
        Right
    }
    
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        [SerializeField] private PointerHandler leftPointerHandler;
        [SerializeField] private PointerHandler rightPointerHandler;

        public event OnTouch OnTouchStart;
        public event OnTouch OnTouchEnd;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            leftPointerHandler.OnTouchStart += () =>
            {
                OnTouchStart?.Invoke(SideType.Left);
            };

            leftPointerHandler.OnTouchEnd += () =>
            {
                OnTouchEnd?.Invoke(SideType.Left);
            };

            rightPointerHandler.OnTouchStart += () =>
            {
                OnTouchStart?.Invoke(SideType.Right);
            };

            rightPointerHandler.OnTouchEnd += () =>
            {
                OnTouchEnd?.Invoke(SideType.Right);
            };
        }
    }
}
