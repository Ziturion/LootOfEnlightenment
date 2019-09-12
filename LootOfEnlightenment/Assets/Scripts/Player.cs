using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class Player : MovableObject
{
    public static event Action OnPlayerDied;
    public static event Action OnLvlUp;
    //public GameObject Staff;
    //public Transform StaffAttackPos;

    public AoEEffect AoEEffect;

    public float MovementSpeed = 0.1f;
    public float AttackCharge = 2f;
    public float ProjectileSpeed = 0.25f;
    public float AttackDamage = 5f;
    public int MaxAmmo = 50;
    public float AttackSpeed = .2f;

    public float SpecialSpeed = 10f;
    public float SpecialRadius = 3.5f;
    public float SpecialDamage = 8f;

    private float _attackSpeedTime;
    public float SpecialSpeedTime { get; private set; }

    public float AttackMultiplayer { get; private set; }

    private Animator _anim;
    private bool _attacking;
    public int Experience { get; private set; }
    public int PlayerLevel { get; private set; }
    public int RequiredExp { get; private set; }
    public int Ammo { get; private set; }

    private AudioSource _audioSource;

    public AudioClip ShootSound;
    public AudioClip AoESound;
    public AudioClip DamageSound;

    private float _normalVolume;
    public float ShootSoundVolume = 0.15f;

    private bool _blocked;
    //private Vector3 IdleStaffPos;

    protected override void Awake()
    {
        base.Awake();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        Ammo = MaxAmmo;
        PlayerLevel = 1;
        RequiredExp = CalculateRequiredExp();
        AttackMultiplayer = 1;
        _normalVolume = _audioSource.volume;
        //IdleStaffPos = Staff.transform.localPosition;
    }

    void Update()
    {
        if (_blocked)
            return;
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookAt = mouseScreenPosition;

        float angleDeg = (180 / Mathf.PI) * Mathf.Atan2(lookAt.y - transform.position.y, lookAt.x - transform.position.x);

        transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);

        _attackSpeedTime -= Time.deltaTime;
        SpecialSpeedTime -= Time.deltaTime;

        if (Input.anyKey)
        {
            Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), MovementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Ammo > 0)
        {
            StartAttack();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopAttack();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (SpecialSpeedTime <= 0)
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, SpecialRadius);
                foreach (Collider2D c in hitColliders)
                {
                    if (c.gameObject.CompareTag("Enemy"))
                        c.gameObject.GetComponent<MovableObject>().OnDamaged(SpecialDamage);
                }
                SpecialSpeedTime = SpecialSpeed;
                Instantiate(AoEEffect, transform.position, Quaternion.identity);
                _audioSource.volume = _normalVolume;
                _audioSource.clip = AoESound;
                _audioSource.Play();
            }
        }

        if (_attacking)
        {
            if (_attackSpeedTime < 0)
            {
                ProjectilePool.Instance.SpawnProjectile(transform.position + transform.up, transform.up, AttackDamage * AttackMultiplayer, ProjectileSpeed);
                Ammo--;
                _attackSpeedTime = AttackSpeed;

                _anim.Play("PlayerAttack");
                _audioSource.volume = ShootSoundVolume;
                _audioSource.clip = ShootSound;
                _audioSource.Play();
            }
            //AttackMultiplayer = Mathf.Clamp(AttackMultiplayer + Time.deltaTime, 1, AttackCharge);
            if(Ammo <= 0)
            {
                StopAttack();
            }
        }
    }

    private void StopAttack()
    {
        //Vector3 dir = Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f);
        //ProjectilePool.Instance.SpawnProjectile(transform.position + transform.up, transform.up, AttackDamage * AttackMultiplayer, ProjectileSpeed);
        //Ammo--;
        _attacking = false;
        AttackMultiplayer = 1;
        //Staff.transform.localPosition = IdleStaffPos;
    }

    private void StartAttack()
    {
        _attacking = true;
        //Staff.transform.localPosition = StaffAttackPos.localPosition;
    }

    public override void OnKilled()
    {
        Debug.Log("Player Ded.");
        _blocked = true;
        OnPlayerDied?.Invoke();
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

        if (Experience >= RequiredExp)
        {
            PlayerLevel++;
            Experience -= RequiredExp;
            RequiredExp = CalculateRequiredExp();
            IncreaseStats();
            OnLvlUp?.Invoke();
        }
    }

    private int CalculateRequiredExp()
    {
        return 25 * (PlayerLevel + 1) * (1 + (PlayerLevel + 1));
    }

    private void IncreaseStats()
    {
        AttackDamage += Random.Range(1, 3);
        MaxHealth += Random.Range(1, 4);
        MaxAmmo += Random.Range(1, 4);
        AttackSpeed *= Random.Range(.93f, .96f);
    }

    public override void OnDamaged(float damage)
    {
        base.OnDamaged(damage);
        _audioSource.volume = _normalVolume;
        _audioSource.clip = DamageSound;
        _audioSource.Play();
    }
}
