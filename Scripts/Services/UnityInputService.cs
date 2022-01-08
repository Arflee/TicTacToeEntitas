using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInputService : IInputService
{
    private Camera _mainCamera = Camera.main;

    public Vector3 MousePosition => _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    public bool MouseLeftClick => Input.GetMouseButtonDown(0);
}
