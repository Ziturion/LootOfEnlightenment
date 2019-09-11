using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string Type;

    private int _bonusHeal = 5;
    private int _bonusAmmo = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))   //health, ammo, experience, 
        {
            Debug.Log(Type);
            switch(Type)
            {
                case "Heal":
                    collision.gameObject.GetComponent<Player>().AddHealth(_bonusHeal);
                    break;
                case "Ammo":
                    collision.gameObject.GetComponent<Player>().AddAmmo(_bonusAmmo);
                    break;
                case "Exp":
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
