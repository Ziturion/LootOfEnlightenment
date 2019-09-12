using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public MeleeEnemy EnemyPrefab;
    //public Object EnemyPrefab2;
    public void SpawnEnemy(int wave)
    {
        wave++;
        MeleeEnemy spawnedEnemy = Instantiate(EnemyPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
        spawnedEnemy.MaxHealth += Random.Range(1 * wave + 1, 4 * wave);
        spawnedEnemy.Speed *= 1;
        spawnedEnemy.Health = spawnedEnemy.MaxHealth;
    }
}
