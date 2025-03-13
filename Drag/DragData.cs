using UnityEngine.EventSystems;

namespace NotActualDev.InputSystem
{
    public struct DragData
    {
        public PointerEventData Pointer { get; private set; }

        public DragData(PointerEventData pointer)
        {
            this.Pointer = pointer;
        }
    }

}
