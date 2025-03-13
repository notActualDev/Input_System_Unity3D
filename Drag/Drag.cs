using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotActualDev.InputSystem
{
    [RequireComponent(typeof(PointerCollector))]
    [DefaultExecutionOrder(-9999)]
    public class Drag : MonoBehaviour, IDrag
    {
        public event Action<DragData> Dragged;
        PointerCollector pointerCollector;

        void OnPointerDrag(PointerEventData pointer)
        {
            if (pointerCollector.pointersDown.Count == 1)
            {
                DragData dragData = new DragData(pointer);
                Dragged?.Invoke(dragData);
            }
        }

        void OnPointerUp(PointerEventData pointer)
        {
            if (pointerCollector.pointersDown.Count == 1)
            {
                DragData dragData = new DragData(pointer);
                Dragged?.Invoke(dragData);
            }
        }

        void Awake()
        {
            pointerCollector = GetComponent<PointerCollector>();
        }

        void OnEnable()
        {
            pointerCollector.PointerUp += OnPointerUp;
            pointerCollector.PointerDrag += OnPointerDrag;
        }

        void OnDisable()
        {
            pointerCollector.PointerUp -= OnPointerUp;
            pointerCollector.PointerDrag -= OnPointerDrag;
        }
    } 
}
