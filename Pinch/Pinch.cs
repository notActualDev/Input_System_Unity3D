using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotActualDev.InputSystem
{
    [RequireComponent(typeof(PointerCollector))]
    [DefaultExecutionOrder(-9999)]
    public class Pinch : MonoBehaviour, IPinch
    {
        public event Action<PinchData> Pinched;

        PointerCollector pointerCollector;
        PointerEventData pointer0;
        PointerEventData pointer1;

        void OnPointerDrag(PointerEventData pointer)
        {
            if (pointerCollector.pointersDown.Count == 2)
            {
                pointer0 = pointerCollector.pointersDown[0];
                pointer1 = pointerCollector.pointersDown[1];
            }
        }

        void OnPointerUp(PointerEventData pointer)
        {
            if (pointerCollector.pointersDown.Count == 2)
            {
                pointer0 = pointerCollector.pointersDown[0];
                pointer1 = pointerCollector.pointersDown[1];
            }
        }

        void Update()
        {
            if (pointer0 != null && pointer1 != null)
            {
                PinchData pinchData = new PinchData(pointer0, pointer1);
                Pinched?.Invoke(pinchData);
                pointer0 = null;
                pointer1 = null;
            }
        }

        void Awake()
        {
            pointerCollector = GetComponent<PointerCollector>();
        }

        void OnEnable()
        {
            pointerCollector.PointerDrag += OnPointerDrag;
            pointerCollector.PointerUp += OnPointerUp;
        }

        void OnDisable()
        {
            pointerCollector.PointerDrag -= OnPointerDrag;
            pointerCollector.PointerUp -= OnPointerUp;
        }
    }
}
