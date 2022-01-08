using UnityEngine;
using Entitas;

public class GameUiController : MonoBehaviour
{
    [SerializeField] private GameObject winningPanel;

    private Systems _systems;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;

        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("GameUi")
            .Add(new GameStopUiHandler(winningPanel))
            .Add(new GameStopSystem(contexts, new GameStopUiHandler(winningPanel)));
    }
}
