using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;

public class MouseRayCollidingSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _gameContext;
    private readonly Camera _mainCamera;

    public MouseRayCollidingSystem(Contexts contexts) : base(contexts.input)
    {
        _gameContext = contexts.game;
        _mainCamera = Camera.main;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var convertedMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(convertedMousePosition, Vector2.zero);

        if (hit)
        {
            var clickedColliders = _gameContext.GetGroup(GameMatcher.Collider)
                .AsEnumerable()
                .Where(c => c.collider.value == hit.collider);

            foreach (var clickedCollider in clickedColliders)
            {
                clickedCollider.isClicked = true;
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.MouseDown));
    }
}
