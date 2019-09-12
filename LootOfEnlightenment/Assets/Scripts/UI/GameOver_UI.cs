using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_UI : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject GUICanvas;

    public TMP_Text WaveText;

    void OnEnable()
    {
        HeavensDoor.OnGameOver += OnGameOver;
        Player.OnPlayerDied += OnGameOver;
    }

    void OnDisable()
    {
        HeavensDoor.OnGameOver -= OnGameOver;
        Player.OnPlayerDied -= OnGameOver;
    }

    public void OnGameOver()
    {
        GameOverPanel.transform.Find("WaveValue").GetComponent<TextMeshProUGUI>().SetText(FindObjectOfType<GameManager>().WaveNumber.ToString());
        GameOverPanel.SetActive(true);
        Time.timeScale = 0.1f;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
