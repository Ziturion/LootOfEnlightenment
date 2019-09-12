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

    public void SpawnEnemyDrops(Vector3 playerPosition)
    {
        for(int i = 10; i >= 0; i--)
        {
            PickUp spawnedItem = Instantiate(ExpPrefab, playerPosition, Quaternion.identity);
            spawnedItem.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(GetRandomBigNumber(), GetRandomBigNumber()));
        }
        for(int i = 2; i >= 0; i--)
        {
            PickUp spawnedAmmo = Instantiate(AmmoPrefab, playerPosition, Quaternion.identity);
            spawnedAmmo.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(GetRandomBigNumber(), GetRandomBigNumber()));
        }
    }

    private float GetRandomBigNumber()
    {
        float randomNum = 0;
        do
        {
            randomNum = Random.Range(-200, 200);

        } while (randomNum <= 20 && randomNum >= -20);
        return randomNum;
    }
}
