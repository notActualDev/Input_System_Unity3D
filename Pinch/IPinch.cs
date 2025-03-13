using System;

namespace NotActualDev.InputSystem
{
    public interface IPinch
	{
		event Action<PinchData> Pinched;
	} 
}
