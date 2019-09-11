using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float SpawnCooldown = 1.5f;
    private float _spawnCooldown = 1.5f;
    void Update()
    {
        _spawnCooldown -= Time.deltaTime;
        if(_spawnCooldown <= 0)
        {
            GetComponent<Spawner>().SpawnEnemy();
            _spawnCooldown = SpawnCooldown;
        }
    }
}
