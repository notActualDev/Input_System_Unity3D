//using System;
//using UnityEngine;
//using UnityEngine.EventSystems;

//namespace NotActualDev.InputSystem
//{
//    [RequireComponent(typeof(PointerCollectorOld))]
//    [DefaultExecutionOrder(-9999)]
//    public class DragOld : MonoBehaviour, IDragHandler, IDrag
//    {
//        public event Action<DragData> Dragged;
//        PointerCollectorOld pointerCollector;

//        void Awake()
//        {
//            pointerCollector = GetComponent<PointerCollectorOld>();
//        }

//        public void OnDrag(PointerEventData pointer)
//        {
//            if (pointerCollector.PointersDownCount == 1)
//            {
//                DragData dragData = new DragData(pointer);
//                Dragged?.Invoke(dragData);
//            }
//        }
//    }
//}
