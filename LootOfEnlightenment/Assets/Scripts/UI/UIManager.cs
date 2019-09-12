using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Player Player;
    public TileBar_UI HealthBar;
    public TileBar_UI ChargeBar;
    public TileBar_UI XPBar;

    private void Update()
    {
        HealthBar.SetValue(Player.Health / Player.MaxHealth);
        ChargeBar.SetValue(((Player.AttackMultiplayer / Player.AttackCharge)-0.5f)*2);
        XPBar.SetValue((float)Player.Experience / Player.RequiredExp);
    }
}
