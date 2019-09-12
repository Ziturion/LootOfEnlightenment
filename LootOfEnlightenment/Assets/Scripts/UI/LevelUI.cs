using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TMP_Text Text;

    void Update()
    {
        Text.text = GameManager.Instance.ActivePlayer.PlayerLevel.ToString();
    }
}