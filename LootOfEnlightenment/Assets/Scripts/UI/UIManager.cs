using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Player _player;
    public TileBar_UI HealthBar;
    public TileBar_UI ChargeBar;
    public TileBar_UI XPBar;

    void Start()
    {
        _player = GameManager.Instance.ActivePlayer;
    }

    private void Update()
    {
        HealthBar.SetValue(_player.Health / _player.MaxHealth);
        ChargeBar.SetValue(((_player.AttackMultiplayer / _player.AttackCharge)-0.5f)*2);
        XPBar.SetValue((float)_player.Experience / _player.RequiredExp);
    }
}
