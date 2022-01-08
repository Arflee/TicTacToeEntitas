using UnityEngine;
using Entitas;
using Entitas.Unity;
using System.Collections.Generic;

public class CreateGameFieldSystem : IInitializeSystem
{
    private readonly Transform _parentFolder = new GameObject("Game Field").transform;
    private readonly GameContext _gameContext;

    public CreateGameFieldSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
    }

    public void Initialize()
    {
        var fieldSize = _gameContext.gameSetup.value.gameFieldSize;
        var cellPrefab = _gameContext.gameSetup.value.gameCellPrefab;
        var cellSize = cellPrefab.transform.localScale;

        for (int y = 0; y < fieldSize; y++)
        {
            for (int x = 0; x < fieldSize; x++)
            {
                var placingPosition = -cellSize * (fieldSize - 1) / 2;
                placingPosition += new Vector3(cellSize.x * x, cellSize.y * y);

                var placedObject = Object.Instantiate(
                        cellPrefab,
                        placingPosition,
                        Quaternion.identity,
                        _parentFolder
                );

                var collider = placedObject.GetComponent<Collider2D>();

                var cellEntity = _gameContext.CreateEntity();

                cellEntity.AddCellId(new Vector2Int(x, y));
                cellEntity.AddCollider(collider);
                cellEntity.AddView(placedObject);
            }
        }
    }
}
