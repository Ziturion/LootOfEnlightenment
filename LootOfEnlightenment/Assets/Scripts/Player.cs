using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MovableObject
{
    public float MovementSpeed = 0.1f;
    public float AttackCharge = 2f;
    public float ProjectileSpeed = 0.25f;
    public float AttackDamage = 5f;

    public float AttackMultiplayer { get; private set; }

    private Animator _anim;
    private bool attacking;
    

    protected override void Awake()
    {
        base.Awake();
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
            AttackMultiplayer = Mathf.Clamp(AttackMultiplayer + Time.deltaTime, 1, AttackCharge);
        }
    }

    private void StopAttack()
    {
        Vector3 dir = Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f);
        ProjectilePool.Instance.SpawnProjectile(transform.position, dir, AttackDamage * AttackMultiplayer, ProjectileSpeed);
        attacking = false;
        AttackMultiplayer = 1;
    }

    private void StartAttack()
    {
        if (!attacking)
            _anim.Play("PlayerAttack");

        attacking = true;
    }

    public override void OnKilled()
    {
        Debug.Log("Player Ded.");
    }
}
