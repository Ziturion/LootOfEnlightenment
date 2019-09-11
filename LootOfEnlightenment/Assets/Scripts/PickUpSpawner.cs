using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public PickUp HealPrefab;
    public PickUp AmmoPrefab;
    public PickUp ExpPrefab;

    public void SpawnItems()
    {
        float randomNum = Random.Range(1, 100);

        if (randomNum <= 50)
            Instantiate(HealPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
        else if (randomNum > 50)
            Instantiate(AmmoPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
    }
}
