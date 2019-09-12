using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private float _lifetime;
    private void Awake()
    {
        _lifetime = GetComponentInChildren<ParticleSystem>().main.duration;
    }

    private void Update()
    {
        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0)
            Destroy(gameObject);
    }
}
