using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject CreditsPanel;
    public GameObject CharaterSelectionPanel;

    public void StartGame(int character)
    {
        PlayerPrefs.SetInt("Character",character);
        SceneManager.LoadScene("MainScene");
    }

    public void BackToStartPanel()
    {
        CreditsPanel.SetActive(false);
        CharaterSelectionPanel.SetActive(false);

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
            case "Selection":
                CharaterSelectionPanel.SetActive(true);
                break;
            default:
                break;
        }
    }
}
