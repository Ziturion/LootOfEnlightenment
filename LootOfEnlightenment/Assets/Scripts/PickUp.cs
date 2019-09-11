using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string Type;

    private float _bonusSpeed = 1.5f;
    private int _bonusHeal = 5;
    private int _bonusAmmo = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")   //health, ammo, experience, 
        {
            switch(Type)
            {
                case "Heal":
                    collision.gameObject.GetComponent<Player>().Health += collision.gameObject.GetComponent<Player>().StartHealth / 5;
                    break;
                //case "Speed":
                //    collision.gameObject.GetComponent<Player>().MovementSpeed *= 1.5f;
                //    break;
                case "Ammo":
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
