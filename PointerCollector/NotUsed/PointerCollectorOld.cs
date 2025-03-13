//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//namespace NotActualDev.InputSystem
//{
//    // This script must be executed earlier than Drag, Swipe etc. because it keeps track of pointers.
//    [DefaultExecutionOrder(-10000)]
//    public class PointerCollectorOld : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
//    {
//        public List<PointerEventData> PointersDown => pointersDown;

//        List<PointerEventData> pointersOver = new List<PointerEventData>(5);
//        List<PointerEventData> pointersDown = new List<PointerEventData>(5);

//        public int PointersOverCount => pointersOver.Count;
//        public int PointersDownCount => pointersDown.Count;

//        //public bool PointersOverContains(PointerEventData p)
//        //{
//        //    return pointersOver.Contains(p);
//        //}

//        //public bool PointersDownContains(PointerEventData p)
//        //{
//        //    return pointersDown.Contains(p);
//        //}

//        public void OnPointerEnter(PointerEventData p)
//        {
//            pointersOver.Add(p);
//        }

//        public void OnPointerExit(PointerEventData p)
//        {
//            //pointersOver.Remove(p);
//            //StartCoroutine(RemovePointer(p, pointersOver));
//        }

//        public void OnPointerDown(PointerEventData p)
//        {
//            pointersDown.Add(p);
//        }

//        public void OnPointerUp(PointerEventData p)
//        {
//            //pointersDown.Remove(p);
//            StartCoroutine(RemovePointer(p, pointersDown));
//            //print($"{Time.frameCount}_PointerUp_PointerCollector.pointersDown.count: {pointersDown.Count}");
//            print($"PointerCollector PointerUp.delta: [{Time.frameCount}] {p.delta}");

//        }

//        IEnumerator RemovePointer(PointerEventData pointer, List<PointerEventData> list)
//        {
//            //print($"Removing coroutine start: {Time.frameCount}");

//            yield return new WaitForEndOfFrame();
//            list.Remove(pointer);
//            //print($"Removing coroutine end: {Time.frameCount}");

//        }

//        private void OnEnable()
//        {
//            foreach (var p in pointersOver)
//            {
//                if (p.pointerEnter != gameObject) pointersOver.Remove(p);
//            }

//            foreach (var p in pointersDown)
//            {
//                if (p.pointerPress != gameObject) pointersDown.Remove(p);
//            }
//        }
//    }
//}
