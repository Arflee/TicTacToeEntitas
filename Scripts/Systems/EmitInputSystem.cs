using Entitas;
using UnityEngine;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    private readonly InputContext _context;
    private InputEntity _leftMouseEntity;
    private Camera _mainCamera;
    private IInputService _inputService;

    public EmitInputSystem(Contexts contexts, IInputService inputService)
    {
        _context = contexts.input;
        _inputService = inputService;
    }

    public void Initialize()
    {
        _context.isLeftMouse = true;
        _leftMouseEntity = _context.leftMouseEntity;
        _mainCamera = Camera.main;
    }

    public void Execute()
    {
        if (_inputService.MouseLeftClick && _context.isLeftMouse)
        {
            _leftMouseEntity.ReplaceMouseDown(_inputService.MousePosition);
        }
    }

    
}
