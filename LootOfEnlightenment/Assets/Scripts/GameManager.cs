using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _spawnCooldown = 1.5f;
    void Update()
    {
        _spawnCooldown -= Time.deltaTime;
        if(_spawnCooldown <= 0)
        {
            GetComponent<Spawner>().SpawnEnemy();
            _spawnCooldown = 1.5f;
        }
    }
}
