using UnityEngine;
using Entitas;

public class InitializeSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public InitializeSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var gameWatcher = _context.CreateEntity();
        var gameFieldSize = _context.gameSetup.value.gameFieldSize;
        gameWatcher.AddGameWatcher(new PlayerFigureComponent.Figure[gameFieldSize, gameFieldSize]);

        //TODO
        var choosenFigure = (PlayerFigureComponent.Figure)Random.Range(1, 3);

        var playerEntity = _context.CreateEntity();
        playerEntity.AddPlayerFigure(choosenFigure);
        playerEntity.isPlayer = true;
    }
}
