using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject CreditsPanel;
    public GameObject CharaterSelectionPanel;

    public AudioClip ButtonSound;

    private AudioSource _source;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = ButtonSound;
    }

    public void StartGame(int character)
    {
        PlayerPrefs.SetInt("Character",character);
        SceneManager.LoadScene("MainScene");
    }

    public void BackToStartPanel()
    {
        CreditsPanel.SetActive(false);
        CharaterSelectionPanel.SetActive(false);
        _source.Play();
        StartPanel.SetActive(true);
    }

    public void ToPanel(string panelName)
    {
        StartPanel.SetActive(false);
        _source.Play();
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
