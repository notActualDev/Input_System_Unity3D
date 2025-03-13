using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotActualDev.InputSystem
{
    [DefaultExecutionOrder(-10000)]
    public class PointerCollector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event Action<PointerEventData> PointerEnter;
        public event Action<PointerEventData> PointerExit;
        public event Action<PointerEventData> PointerDown;
        public event Action<PointerEventData> PointerUp;
        public event Action<PointerEventData> PointerDrag;

        internal List<PointerEventData> pointersOver = new List<PointerEventData>(5);
        internal List<PointerEventData> pointersDown = new List<PointerEventData>(5);

        public void OnPointerEnter(PointerEventData pointer)
        {
            pointersOver.Add(pointer);
            PointerEnter?.Invoke(pointer);
        }

        public void OnPointerExit(PointerEventData pointer)
        {
            PointerExit?.Invoke(pointer);
            pointersOver.Remove(pointer);
        }

        public void OnPointerDown(PointerEventData pointer)
        {
            pointersDown.Add(pointer);
            PointerDown?.Invoke(pointer);
        }

        public void OnPointerUp(PointerEventData pointer)
        {
            PointerUp?.Invoke(pointer);
            pointersDown.Remove(pointer);
        }

        public void OnDrag(PointerEventData pointer)
        {
            PointerDrag?.Invoke(pointer);
        }

        private void OnEnable()
        {
            foreach (var p in pointersOver)
            {
                if (p.pointerEnter != gameObject) pointersOver.Remove(p);
            }

            foreach (var p in pointersDown)
            {
                if (p.pointerPress != gameObject) pointersDown.Remove(p);
            }
        }
    } 
}
