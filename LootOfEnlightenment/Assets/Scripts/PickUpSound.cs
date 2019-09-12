using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PickUpSound : MonoBehaviour
{
    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        PickUp.OnCollected += Collected;
    }

    void OnDisable()
    {
        PickUp.OnCollected -= Collected;
    }

    void Collected()
    {
        _source.Play();
    }
}
