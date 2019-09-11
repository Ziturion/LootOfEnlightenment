using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;
    private float _damage;
    private bool _initilized;

    public void Init(Vector3 direction, float damage, float speed)
    {
        _initilized = true;
        _direction = direction.normalized;
        _damage = damage;
        _speed = speed;
    }

    private void Update()
    {
        if (!_initilized)
            return;

        transform.position += _direction * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
    }
}
