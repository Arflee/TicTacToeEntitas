using UnityEngine;
using Entitas;

public class GameStopUiHandler : IInitializeSystem, IStopService
{
    private GameObject _winningPanel;

    public GameStopUiHandler(GameObject panel)
    {
        _winningPanel = panel;
    }

    public void Initialize()
    {
        _winningPanel.SetActive(false);
    }

    public void Stop()
    {
        _winningPanel.SetActive(true);
    }
}
