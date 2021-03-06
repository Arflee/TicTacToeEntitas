//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameWatcherEntity { get { return GetGroup(GameMatcher.GameWatcher).GetSingleEntity(); } }
    public GameWatcherComponent gameWatcher { get { return gameWatcherEntity.gameWatcher; } }
    public bool hasGameWatcher { get { return gameWatcherEntity != null; } }

    public GameEntity SetGameWatcher(PlayerFigureComponent.Figure[,] newFigures) {
        if (hasGameWatcher) {
            throw new Entitas.EntitasException("Could not set GameWatcher!\n" + this + " already has an entity with GameWatcherComponent!",
                "You should check if the context already has a gameWatcherEntity before setting it or use context.ReplaceGameWatcher().");
        }
        var entity = CreateEntity();
        entity.AddGameWatcher(newFigures);
        return entity;
    }

    public void ReplaceGameWatcher(PlayerFigureComponent.Figure[,] newFigures) {
        var entity = gameWatcherEntity;
        if (entity == null) {
            entity = SetGameWatcher(newFigures);
        } else {
            entity.ReplaceGameWatcher(newFigures);
        }
    }

    public void RemoveGameWatcher() {
        gameWatcherEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameWatcherComponent gameWatcher { get { return (GameWatcherComponent)GetComponent(GameComponentsLookup.GameWatcher); } }
    public bool hasGameWatcher { get { return HasComponent(GameComponentsLookup.GameWatcher); } }

    public void AddGameWatcher(PlayerFigureComponent.Figure[,] newFigures) {
        var index = GameComponentsLookup.GameWatcher;
        var component = (GameWatcherComponent)CreateComponent(index, typeof(GameWatcherComponent));
        component.figures = newFigures;
        AddComponent(index, component);
    }

    public void ReplaceGameWatcher(PlayerFigureComponent.Figure[,] newFigures) {
        var index = GameComponentsLookup.GameWatcher;
        var component = (GameWatcherComponent)CreateComponent(index, typeof(GameWatcherComponent));
        component.figures = newFigures;
        ReplaceComponent(index, component);
    }

    public void RemoveGameWatcher() {
        RemoveComponent(GameComponentsLookup.GameWatcher);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameWatcher;

    public static Entitas.IMatcher<GameEntity> GameWatcher {
        get {
            if (_matcherGameWatcher == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameWatcher);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameWatcher = matcher;
            }

            return _matcherGameWatcher;
        }
    }
}
