using UnityEngine;


public interface IInputService
{
    Vector3 MousePosition { get; }
    bool MouseLeftClick { get; }
}

