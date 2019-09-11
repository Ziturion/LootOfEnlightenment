using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MovableObject
{
    public float MovementSpeed = 0.1f;
    public float AttackCharge = 2f;
    public float ProjectileSpeed = 0.25f;
    public float AttackDamage = 5f;
    public int MaxAmmo = 50;

    public float AttackMultiplayer { get; private set; }

    private Animator _anim;
    private bool _attacking;
    private int _experience = 0;
    private int _playerLevel = 1;
    private int _requiredExp = 0;
    public int Ammo { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _anim = GetComponent<Animator>();
        Ammo = MaxAmmo;
        _requiredExp = CalculateRequiredExp();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), MovementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Ammo != 0)
        {
            StartAttack();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && Ammo != 0)
        {
            StopAttack();
        }

        if (_attacking)
        {
            AttackMultiplayer = Mathf.Clamp(AttackMultiplayer + Time.deltaTime, 1, AttackCharge);
        }
    }

    private void StopAttack()
    {
        Vector3 dir = Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f);
        ProjectilePool.Instance.SpawnProjectile(transform.position, dir, AttackDamage * AttackMultiplayer, ProjectileSpeed);
        Ammo--;
        _attacking = false;
        AttackMultiplayer = 1;
    }

    private void StartAttack()
    {
        if (!_attacking)
            _anim.Play("PlayerAttack");

        _attacking = true;
    }

    public override void OnKilled()
    {
        Debug.Log("Player Ded.");
    }

    public void AddAmmo(int value)
    {
        Ammo = Mathf.Clamp(Ammo + value, 0, MaxAmmo);
    }

    public void AddHealth(int value)
    {
        Health = Mathf.Clamp(Health + value, 0, MaxHealth);
    }

    public void AddExp(int value)
    {
        _experience += value;
        
        if(_experience >= _requiredExp)
        {
            _playerLevel++;
            _experience -= _requiredExp;
            _requiredExp = CalculateRequiredExp();
        }
    }

    private int CalculateRequiredExp()
    {
        return 25 * (_playerLevel + 1) * (1 + (_playerLevel + 1));
    }
}
