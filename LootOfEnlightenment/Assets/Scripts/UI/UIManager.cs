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
        ChargeBar.SetValue(1 - (_player.SpecialSpeedTime / _player.SpecialSpeed));
        XPBar.SetValue((float)_player.Experience / _player.RequiredExp);
    }
}
