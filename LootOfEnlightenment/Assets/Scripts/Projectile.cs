using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Lifetime = 3f;

    private Vector3 _direction;
    private float _speed;
    private float _damage;
    private bool _initilized;
    private float _lifetime;

    public void Init(Vector3 direction, float damage, float speed)
    {
        _initilized = true;
        _direction = direction.normalized;
        _damage = damage;
        _speed = speed;
        _lifetime = Lifetime;
    }

    private void Update()
    {
        if (!_initilized)
            return;

        transform.position += _direction * _speed;
        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0)
        {
            KillProjectile();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<MeleeEnemy>().HitInDirection(_direction);
        }

        IAttackable attacked = other.gameObject.GetComponent<IAttackable>();
        attacked?.OnDamaged(_damage);

        KillProjectile();
    }

    private void KillProjectile()
    {
        gameObject.SetActive(false);
    }
}
