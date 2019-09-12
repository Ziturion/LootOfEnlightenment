using TMPro;
using UnityEngine;


public class AmmoUI : MonoBehaviour
{
    public TMP_Text Text;

    void Update()
    {
        Text.text = GameManager.Instance.ActivePlayer.Ammo.ToString("00");
    }
}