using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Player Player;
    public TileBar_UI HealthBar;
    public TileBar_UI ChargeBar;

    private void Update()
    {
        HealthBar.SetValue(Player.Health / Player.MaxHealth);
        ChargeBar.SetValue(((Player.AttackMultiplayer / Player.AttackCharge)-0.5f)*2);
    }
}
