using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MovableObject
{
    public float MovementSpeed = 0.1f;
    public float AttackCharge = 1f;
    public float ProjectileSpeed = 0.25f;

    public float AttackLength { get; private set; }

    private Animator _anim;
    private bool attacking;
    

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), MovementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttack();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopAttack();
        }

        if (attacking)
        {
            AttackLength = Mathf.Clamp(AttackLength + Time.deltaTime, 0, AttackCharge);
        }
    }

    private void StopAttack()
    {
        Vector3 dir = Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f);
        ProjectilePool.Instance.SpawnProjectile(transform.position, dir, AttackLength, ProjectileSpeed);
        attacking = false;
        AttackLength = 0;
    }

    private void StartAttack()
    {
        if (!attacking)
            _anim.Play("PlayerAttack");

        attacking = true;
    }
}
