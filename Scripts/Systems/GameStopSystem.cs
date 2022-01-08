using Entitas;
using System.Collections.Generic;

public class GameStopSystem : ReactiveSystem<GameEntity>
{
    private readonly InputContext _inputContext;
    private IStopService _gameStop;

    public GameStopSystem(Contexts contexts, IStopService gameStop) : base(contexts.game)
    {
        _inputContext = contexts.input;
        _gameStop = gameStop;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        _gameStop.Stop();
        _inputContext.isLeftMouse = false;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameStop;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameStop);
    }
}
