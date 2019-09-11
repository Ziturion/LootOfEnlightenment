using TMPro;
using UnityEngine;


public class AmmoUI : MonoBehaviour
{
    public Player PlayerRef;
    public TMP_Text Text;

    void Update()
    {
        Text.text = PlayerRef.Ammo.ToString("00");
    }
}
