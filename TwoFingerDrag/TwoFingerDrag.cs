using System;
using UnityEngine;
using UnityEngine.EventSystems;

// I had some thoughts considering if this class or Drag, Pinch etc. should stop receiving events from PointerCollector or not. But I leave it be now.
namespace NotActualDev.InputSystem
{
    [RequireComponent(typeof(PointerCollector))]
    [DefaultExecutionOrder(-9999)]
    public class TwoFingerDrag : MonoBehaviour, ITwoFingerDrag
    {
        public event Action<TwoFingerDragData> Dragged;

        PointerCollector pointerCollector;
        PointerEventData pointer0;
        PointerEventData pointer1;

        private void OnPointerDrag(PointerEventData pointer)
        {
            if (pointerCollector.pointersDown.Count == 2)
            {
                pointer0 = pointerCollector.pointersDown[0];
                pointer1 = pointerCollector.pointersDown[1];
            }
        }

        private void OnPointerUp(PointerEventData pointer)
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
                TwoFingerDragData dragData = new TwoFingerDragData(pointer0, pointer1);
                Dragged?.Invoke(dragData);
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
