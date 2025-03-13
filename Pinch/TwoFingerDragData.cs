using UnityEngine;
using UnityEngine.EventSystems;

namespace NotActualDev.InputSystem
{
    public struct TwoFingerDragData
    {
        public PointerEventData Pointer0 { get; private set; }
        public PointerEventData Pointer1 { get; private set; }
        public Vector2 Delta { get; private set; }
        public float Magnitude { get; private set; }

        public TwoFingerDragData(PointerEventData pointer0, PointerEventData pointer1)
        {
            this.Pointer0 = pointer0;
            this.Pointer1 = pointer1;

            this.Delta = (pointer0.delta / 2f) + (pointer1.delta / 2f);
            this.Magnitude = Delta.magnitude;
        }
    }
}
