using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public MeleeEnemy EnemyPrefab;
    //public Object EnemyPrefab2;
    public void SpawnEnemy()
    {
        MeleeEnemy spawnedEnemy = Instantiate(EnemyPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
        spawnedEnemy.MaxHealth += 0;        //Scale this
        spawnedEnemy.AttackSpeed *= 1;
        spawnedEnemy.Speed *= 1;
        spawnedEnemy.Health = spawnedEnemy.MaxHealth;
    }
}
