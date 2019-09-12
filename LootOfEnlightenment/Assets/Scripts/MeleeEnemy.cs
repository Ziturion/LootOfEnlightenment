using UnityEngine;
using UnityEngine.UI;

public class MeleeEnemy : MovableObject
{
    public float DetectionRange = 100;
    public float Speed = 0.02f;
    public float AttentionLength = 3;
    public float AttackSpeed = 1.5f;
    public float Damage = 1;
    public Slider HealthSlider;

    private GameObject _target;
    private float _attention;
    private float _attackCooldown;

    protected override void Awake()
    {
        base.Awake();
        _target = GameObject.FindWithTag("HeavensDoor");
    }

    private void Update()
    {
        Vector3 playerInDirection = _target.transform.position - transform.position;
        if(playerInDirection.magnitude < DetectionRange)
        {
            Move(playerInDirection.normalized, Speed);
        }

        _attention -= Time.deltaTime;
        if (_attention <= 0)
        {
            _target = GameObject.FindWithTag("HeavensDoor");
        }

        if (_attackCooldown >= 0)
        {
            _attackCooldown -= Time.deltaTime;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.transform.position.y > transform.position.y)
        {
            if(collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder >= gameObject.GetComponent<SpriteRenderer>().sortingOrder) 
            GetComponent<SpriteRenderer>().sortingOrder = collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
    }

    public override void OnDamaged(float damage)
    {
        base.OnDamaged(damage);
        HealthSlider.gameObject.SetActive(true);
        HealthSlider.value = Health / MaxHealth;
        _target = GameObject.FindWithTag("Player");
        _attention = AttentionLength;
    }

    public override void OnKilled()
    {
        PickUpSpawner expSpawner = GameObject.FindObjectOfType(typeof(PickUpSpawner)) as PickUpSpawner;
        expSpawner.SpawnEnemyDrops(transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            return;
        if (_attackCooldown <= 0)
        {
            IAttackable attacked = other.gameObject.GetComponent<IAttackable>();
            attacked?.OnDamaged(Damage);

            _attackCooldown = AttackSpeed;
        }
    }
}
