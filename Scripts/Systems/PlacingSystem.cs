using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class PlacingSystem : ReactiveSystem<GameEntity>
{
    private readonly Transform _parentFolder = new GameObject("Figures").transform;
    private readonly GameContext _gameContext;

    public PlacingSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var allPlayers =
             _gameContext.GetEntities(
                 GameMatcher.AllOf(GameMatcher.Player, GameMatcher.PlayerFigure)
             );

        var clickedCells =
            _gameContext.GetEntities(
                GameMatcher.AllOf(GameMatcher.Clicked).NoneOf(GameMatcher.Occupied)
            );

        foreach (var player in allPlayers)
        {
            foreach (var cell in clickedCells)
            {
                foreach (var _ in entities)
                {
                    var choosenObject = PlayerFigureToGameObject(player.playerFigure.value);

                    var placedObject = Object.Instantiate(
                        choosenObject,
                        cell.view.gameObject.transform.position, 
                        Quaternion.identity,
                        _parentFolder
                    );

                    var placedEntity = _gameContext.CreateEntity();
                    placedEntity.isTearDown = true;
                    placedEntity.AddView(placedObject);
                    placedEntity.AddPlayerFigure(player.playerFigure.value);

                    cell.isOccupied = true;
                    var clickedCellId = cell.cellId.value;
                    _gameContext.gameWatcher.figures[clickedCellId.x, clickedCellId.y] =
                        player.playerFigure.value;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isClicked && !entity.isOccupied;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Clicked);
    }

    private GameObject PlayerFigureToGameObject(PlayerFigureComponent.Figure figure)
    {
        switch (figure)
        {
            case PlayerFigureComponent.Figure.Cross:
                return _gameContext.gameSetup.value.crossPrefab;

            case PlayerFigureComponent.Figure.Circle:
                return _gameContext.gameSetup.value.circlePrefab;
        }

        return null;
    }
}
