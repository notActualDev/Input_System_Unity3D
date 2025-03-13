//using System;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.InputSystem;

//namespace NotActualDev.InputSystem
//{
//    [RequireComponent(typeof(PointerCollector))]
//    [DefaultExecutionOrder(-999)]
//    public class DragComplicated : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
//    {
//        // down i initialize maj¹ zawsze delta == 0,0 (nawet jak full dynamic)
//        // beginDrag ma to samo co nastepujacy zaraz po nim Drag (wiec ignoruj beginDrag)
//        // Up i endDrag maj¹ te same Delta

//        public event Action DragStarted;
//        public event Action DragResumed;
//        public event Action Dragged; // DragData
//        public event Action DragSuspended;
//        public event Action DragFinished;

//        //public PointerEventData ActivePointer => activePointer;

//        public bool Interactable
//        {
//            get => interactable;
//            set
//            {

//            }
//        }

//        ///// <summary>
//        ///// If you drag with finger A, then you add finger B (so it stops processing dragging, because now 2 fingers are pressed at the same time), 
//        ///// then you release finger A (the one that was dragging), you can continue dragging with finger B that stayed pressed.
//        ///// </summary>
//        //public bool CanContinueDragWithDifferentPointer
//        //{
//        //    get => canContinueDragWithDifferentPointer;
//        //    set => canContinueDragWithDifferentPointer = value;
//        //}
//        ///// <summary>
//        ///// If you drag with finger A, then you add finger B (so it stops processing dragging, because now 2 fingers are pressed at the same time), 
//        ///// then you release finger A (the one that was dragging), you can continue dragging with finger B that stayed pressed.
//        ///// </summary>
//        //[SerializeField] bool canContinueDragWithDifferentPointer = true;

//        PointerCollector pointerCollector;
//        //PointerEventData activePointer;
//        bool used = false;

//        //public bool IsProcessingInput()
//        //{
//        //    if (activePointer != null && pointerCollector.PointersDownCount() == 1) return true;
//        //    else return false;
//        //}

//        private bool interactable;

//        void Awake()
//        {
//            pointerCollector = GetComponent<PointerCollector>();
//        }

//        void OnEnable()
//        {
//            if (used)
//            {
//                if (pointerCollector.PointersDownCount == 0)
//                {
//                    DragFinished?.Invoke();
//                    used = false;
//                }
//            }


//            //if (activePointer != null && !pointerCollector.PointersDownContains(activePointer))
//            //    {
//            //        DragFinished?.Invoke();
//            //        activePointer = null;
//            //    }
//            // interactive
//        }

//        void OnDisable()
//        {
//            // drag suspended or finished 


//            //DragFinished
//            // end drag invoke
//            //if (activePointer != null)
//        }

//        public void OnPointerDown(PointerEventData p)
//        {
//            if (pointerCollector.PointersDownCount == 1)
//            {
//                used = true;
//                DragStarted?.Invoke();
//            }
//            else
//            {
//                DragSuspended?.Invoke();
//            }
//        }

//        public void OnDrag(PointerEventData p)
//        {
//            if (pointerCollector.PointersDownCount == 1)
//            {
//                Dragged?.Invoke();
//            }
//        }

//        public void OnPointerUp(PointerEventData p)
//        {
//            if (pointerCollector.PointersDownCount == 0)
//            {
//                DragFinished?.Invoke();
//                used = false;
//            }
//            else if (pointerCollector.PointersDownCount == 1)
//            {
//                DragResumed?.Invoke();
//            }
//        }
//    } 
//}
