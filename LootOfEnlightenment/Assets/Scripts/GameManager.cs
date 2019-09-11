using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemySpawner;
    public float EnemyCooldown;
    private float _eCooldown;
    public GameObject PickUpSpawner;
    public float PickUpCooldown;
    private float _pCooldown;
    private void Awake()
    {
        _eCooldown = EnemyCooldown;
        _pCooldown = PickUpCooldown;
    }
    void Update()
    {
        _eCooldown -= Time.deltaTime;
        _pCooldown -= Time.deltaTime;
        if(_eCooldown <= 0)
        {
            EnemySpawner.GetComponent<Spawner>().SpawnEnemy();
            _eCooldown = EnemyCooldown;
        }
        if(_pCooldown <= 0)
        {
            PickUpSpawner.GetComponent<PickUpSpawner>().SpawnItems();
            _pCooldown = PickUpCooldown;
        }
    }
}
