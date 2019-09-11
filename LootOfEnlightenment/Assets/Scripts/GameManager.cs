using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemySpawner;
    public float SpawnCooldown;
    private float _sCooldown;
    private void Awake()
    {
        _sCooldown = SpawnCooldown;
    }
    void Update()
    {
        _sCooldown -= Time.deltaTime;
        if(_sCooldown <= 0)
        {
            EnemySpawner.GetComponent<Spawner>().SpawnEnemy();
            _sCooldown = SpawnCooldown;
        }
    }
}
