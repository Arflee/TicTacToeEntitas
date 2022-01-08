using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Text;
using UnityEngine;

[Input, Unique]
public class LeftMouseComponent : IComponent
{
}

[Input]
public class MouseDownComponent : IComponent
{
    public Vector2 position;
}

[Game]
public class PlayerComponent : IComponent
{
    
}

[Game]
public class PlayerFigureComponent : IComponent
{
    public enum Figure
    {
        None,
        Cross,
        Circle
    }

    public Figure value;
}

[Game]
public class PositionComponent : IComponent
{
    public Vector2 value;
}

[Game]
public class ViewComponent : IComponent
{
    public GameObject gameObject;
}

[Game]
public class ColliderComponent : IComponent
{
    public Collider2D value;
}

[Game]
public class ClickedComponent : IComponent
{

}

[Game]
public class OccupiedComponent : IComponent
{

}

[Game, Unique]
public class GameWatcherComponent : IComponent
{
    public PlayerFigureComponent.Figure[,] figures;
}

[Game]
public class CellIdComponent : IComponent
{
    public Vector2Int value;
}

[Game]
public class GameStopComponent : IComponent
{
    public PlayerFigureComponent.Figure[] winningCells;
}

[Game]
public class TearDownComponent : IComponent
{

}