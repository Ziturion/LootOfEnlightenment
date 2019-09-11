using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
    public float SpawnCooldown = 1.5f;
    private float _spawnCooldown = 1.5f;
=======
    public GameObject EnemySpawner;
    public float SpawnCooldown;
    private float _sCooldown;
    private void Awake()
    {
        _sCooldown = SpawnCooldown;
    }
>>>>>>> Stashed changes
    void Update()
    {
        _sCooldown -= Time.deltaTime;
        if(_sCooldown <= 0)
        {
<<<<<<< Updated upstream
            GetComponent<Spawner>().SpawnEnemy();
            _spawnCooldown = SpawnCooldown;
=======
            EnemySpawner.GetComponent<Spawner>().SpawnEnemy();
            _sCooldown = SpawnCooldown;
>>>>>>> Stashed changes
        }
    }
}
