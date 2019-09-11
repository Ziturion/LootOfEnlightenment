using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MovableObject
{
    public float MovementSpeed = 0.1f;
    public float AttackCooldown = 0.1f;

    private float _attackCooldown;
    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), MovementSpeed);

            if (Input.GetAxisRaw("Fire1") > 0 && _attackCooldown < 0)
            {
                _attackCooldown = AttackCooldown;
                Attack();
            }
        }

        if(_attackCooldown >= 0)
        _attackCooldown -= Time.deltaTime;
    }

    private void Attack()
    {
        _anim.Play("PlayerAttack");
    }
}
