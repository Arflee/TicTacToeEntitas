using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderLabel;
    [SerializeField] private GameSetup gameSetup;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSliderLabelText(float value)
    {
        sliderLabel.text = value.ToString();
        gameSetup.gameFieldSize = (uint)value;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
