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

    public void SpawnExp(Vector3 playerPosition)
    {
        PickUp spawnedItem = Instantiate(ExpPrefab, playerPosition, Quaternion.identity);
        spawnedItem.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 1), Random.Range(0, 1)));
    }
}
