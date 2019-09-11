using UnityEngine;
using UnityEngine.UI;

public class HeavensDoor : MonoBehaviour, IAttackable
{
    public float StartHealth = 10f;
    public Slider HealthSlider;

    public float Health { get; set; }

    void Awake()
    {
        Health = StartHealth;
    }

    public void OnDamaged(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            OnKilled();
        }
        HealthSlider.value = Health / StartHealth;
    }

    public void OnKilled()
    {
        Debug.Log("Game Over");
    }
}
