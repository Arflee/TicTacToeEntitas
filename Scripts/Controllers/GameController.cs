using Entitas;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameSetup _setup;

    private Systems _systems;

    private void Start()
    {
        Contexts.sharedInstance.Reset();

        var contexts = Contexts.sharedInstance;
        contexts.game.ReplaceGameSetup(_setup);
            
        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute(); 
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("TicTacToe")
            .Add(new CreateGameFieldSystem(contexts))
            .Add(new InitializeSystem(contexts))
            .Add(new EmitInputSystem(contexts, new UnityInputService()))
            .Add(new MouseRayCollidingSystem(contexts))
            .Add(new PlacingSystem(contexts))
            .Add(new WinConditionsSystem(contexts));
    }
}
