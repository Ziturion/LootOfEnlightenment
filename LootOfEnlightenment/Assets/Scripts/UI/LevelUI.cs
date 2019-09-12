using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public Player PlayerRef;
    public TMP_Text Text;

    void Update()
    {
        Text.text = PlayerRef.PlayerLevel.ToString();
    }
}