using TMPro;
using UnityEngine;


public class DUMMY_ChargeUI : MonoBehaviour
{
    public Player PlayerRef;
    public TMP_Text Text;

    void Update()
    {
        Text.text = PlayerRef.AttackLength.ToString("0.00");
    }
}
