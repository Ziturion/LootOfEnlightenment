using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Object EnemyPrefab;
    public void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
    }
}
