using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Common
{
    public class PointerHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private UnityEvent onTouchStart;
        [SerializeField] private UnityEvent onTouchEnd;
        

        public event UnityAction OnTouchStart
        {
            add => onTouchStart.AddListener(value);
            remove => onTouchStart.RemoveListener(value);
        }
        
        public event UnityAction OnTouchEnd
        {
            add => onTouchEnd.AddListener(value);
            remove => onTouchEnd.RemoveListener(value);
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            onTouchStart?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onTouchEnd?.Invoke();
        }
    }
}