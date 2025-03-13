using System;

namespace NotActualDev.InputSystem
{
    public interface ITwoFingerDrag
    {
        event Action<TwoFingerDragData> Dragged;
    }
}
