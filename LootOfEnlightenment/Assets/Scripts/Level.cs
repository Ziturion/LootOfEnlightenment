using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().OnKilled();
        }
    }
}
