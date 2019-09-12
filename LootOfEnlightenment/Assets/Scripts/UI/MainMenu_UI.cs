using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject CreditsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackToStartPanel()
    {
        CreditsPanel.SetActive(false);

        StartPanel.SetActive(true);
    }

    public void ToPanel(string panelName)
    {
        StartPanel.SetActive(false);
        switch (panelName)
        {
            case "Credits":
                CreditsPanel.SetActive(true);
                break;
            default:
                break;
        }
    }
}
