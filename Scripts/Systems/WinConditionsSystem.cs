using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WinConditionsSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _gameContext;

    public WinConditionsSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var placedFigures = _gameContext.gameWatcher.figures;
        
        //TODO think for a better pick solution
        foreach (var row in placedFigures.GetRows())
        {
            if (CheckForWinning(row))
            {
                _gameContext.gameWatcherEntity.AddGameStop(row);
            }
        }

        foreach (var column in placedFigures.GetColumns())
        {
            if (CheckForWinning(column) && !_gameContext.gameWatcherEntity.hasGameStop)
            {
                _gameContext.gameWatcherEntity.AddGameStop(column);
            }
        }

        foreach (var diagonal in placedFigures.GetDiagonals())
        {
            if (CheckForWinning(diagonal) && !_gameContext.gameWatcherEntity.hasGameStop)
            {
                _gameContext.gameWatcherEntity.AddGameStop(diagonal);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isClicked;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Clicked);
    }

    private bool CheckForWinning(PlayerFigureComponent.Figure[] figures)
    {
        var figuresToWin = _gameContext.gameSetup.value.gameFieldSize;

        var allPlayers =
            _gameContext.GetEntities(
                GameMatcher.AllOf(GameMatcher.Player, GameMatcher.PlayerFigure)
            );

        foreach (var player in allPlayers)
        {
            return figures.Count(e => e == player.playerFigure.value) == figuresToWin;
        }

        return false;
    }
}
