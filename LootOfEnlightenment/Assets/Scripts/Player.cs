using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MovableObject
{
    public float MovementSpeed = 0.1f;
    public float AttackCharge = 2f;
    public float ProjectileSpeed = 0.25f;
    public float AttackDamage = 5f;
    public int MaxAmmo = 50;
    public float AttackSpeed = 1f;

    public float SpecialSpeed = 10f;
    public float SpecialRadius = 4f;
    public float SpecialDamage = 8f;

    private float _attackSpeedTime;
    private float _specialSpeedTime;

    public float AttackMultiplayer { get; private set; }

    private Animator _anim;
    private bool _attacking;
    public int Experience { get; private set; }
    public int PlayerLevel { get; private set; }
    public int RequiredExp { get; private set; }
    public int Ammo { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _anim = GetComponent<Animator>();
        Ammo = MaxAmmo;
        PlayerLevel = 1;
        RequiredExp = CalculateRequiredExp();
        AttackMultiplayer = 1;
    }

    void Update()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookAt = mouseScreenPosition;
        
        float angleDeg = (180 / Mathf.PI) * Mathf.Atan2(lookAt.y - transform.position.y, lookAt.x - transform.position.x);

        transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);

        _attackSpeedTime -= Time.deltaTime;
        _specialSpeedTime -= Time.deltaTime;

        if (Input.anyKey)
        {
            Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), MovementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Ammo >= 0)
        {
            StartAttack();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && Ammo >= 0)
        {
            StopAttack();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (_specialSpeedTime <= 0)
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, SpecialRadius);
                foreach (Collider2D c in hitColliders)
                {
                    if (c.gameObject.CompareTag("Enemy"))
                        c.gameObject.GetComponent<MovableObject>().OnDamaged(SpecialDamage);
                }
                _specialSpeedTime = SpecialSpeed;
            }
        }

        if (_attacking)
        {
            if (_attackSpeedTime <= 0)
            {
                ProjectilePool.Instance.SpawnProjectile(transform.position + transform.up, transform.up, AttackDamage * AttackMultiplayer, ProjectileSpeed);
                Ammo--;
                _attackSpeedTime = AttackSpeed;

                _anim.Play("PlayerAttack");
            }
            //AttackMultiplayer = Mathf.Clamp(AttackMultiplayer + Time.deltaTime, 1, AttackCharge);
        }
    }

    private void StopAttack()
    {
        //Vector3 dir = Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f);
        //ProjectilePool.Instance.SpawnProjectile(transform.position + transform.up, transform.up, AttackDamage * AttackMultiplayer, ProjectileSpeed);
        //Ammo--;
        _attacking = false;
        AttackMultiplayer = 1;
    }

    private void StartAttack()
    {
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
        Experience += value;
        
        if(Experience >= RequiredExp)
        {
            PlayerLevel++;
            Experience -= RequiredExp;
            RequiredExp = CalculateRequiredExp();
            IncreaseStats();
        }
    }

    private int CalculateRequiredExp()
    {
        return 25 * (PlayerLevel + 1) * (1 + (PlayerLevel + 1));
    }

    private void IncreaseStats()
    {
        MaxHealth += Random.Range(1, 4);
        MaxAmmo += Random.Range(1, 4);
        AttackSpeed *= Random.Range(.93f, .96f);
    }
}
