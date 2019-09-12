﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string Type;

    private int _bonusHeal = 5;
    private int _bonusAmmo = 1;
    private int _expGained = 2;

    private AudioSource _audioSourcePU;

    public AudioClip PickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))   //health, ammo, experience, 
        {
            _audioSourcePU.Play();

            switch (Type)
            {
                case "Heal":
                    collision.gameObject.GetComponent<Player>().AddHealth(_bonusHeal);
                    break;
                case "Ammo":
                    collision.gameObject.GetComponent<Player>().AddAmmo(_bonusAmmo);
                    break;
                case "Exp":
                    collision.gameObject.GetComponent<Player>().AddExp(_expGained);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
