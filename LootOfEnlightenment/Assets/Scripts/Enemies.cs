using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MovableObject
{
    private GameObject _playerCharacter;
    public float DetectionRange;
    public float Speed;
    public Slider HealthSlider;

    protected override void Awake()
    {
        base.Awake();
        _playerCharacter = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Vector3 playerInDirection = _playerCharacter.transform.position - transform.position;
        if(playerInDirection.magnitude < DetectionRange)
        {
            Move(playerInDirection.normalized, Speed);
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
        HealthSlider.value = Health / StartHealth;
    }

    public override void OnKilled()
    {
        Destroy(gameObject);
    }
}
