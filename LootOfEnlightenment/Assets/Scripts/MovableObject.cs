using UnityEngine;

public abstract class MovableObject : MonoBehaviour, IAttackable
{
    public float StartHealth = 10f;
    public float Health { get; set; }

    protected virtual void Awake()
    {
        Health = StartHealth;
    }

    protected virtual void Move(Vector3 direction, float speed)
    {
        transform.position += direction.normalized * speed;
    }

    public virtual void OnDamaged(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            OnKilled();
        }
    }

    public abstract void OnKilled();
}
