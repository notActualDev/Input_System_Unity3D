using UnityEngine;
using UnityEngine.EventSystems;

namespace NotActualDev.InputSystem
{
    public struct PinchData
    {
        public PointerEventData Pointer0 { get; private set; }
        public PointerEventData Pointer1 { get; private set; }
        public float Delta { get; private set; }

        public PinchData(PointerEventData pointer0, PointerEventData pointer1)
        {
            this.Pointer0 = pointer0;
            this.Pointer1 = pointer1;

            Vector2 lastPosition0 = pointer0.position - pointer0.delta;
            Vector2 lastPosition1 = pointer1.position - pointer1.delta;

            float lastDistance = Vector2.Distance(lastPosition0, lastPosition1);
            float currentDistance = Vector2.Distance(pointer0.position, pointer1.position);

            this.Delta = currentDistance - lastDistance;
        }
    }
}
