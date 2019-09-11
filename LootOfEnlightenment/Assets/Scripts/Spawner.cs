using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Object EnemyPrefab;
    public Object EnemyPrefab2;
    public void SpawnEnemy()
    {
        Random.Range(0, 1000);
        Instantiate(EnemyPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
        Instantiate(EnemyPrefab2, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
    }
}
