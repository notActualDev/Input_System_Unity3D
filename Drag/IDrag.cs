using System;

namespace NotActualDev.InputSystem
{
    public interface IDrag
    {
        event Action<DragData> Dragged;
    }
}
