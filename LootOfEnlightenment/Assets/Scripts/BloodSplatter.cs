using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    public int MinSplatters = 5;
    public int MaxSplatters = 10;
    public Sprite[] SplatterPrefabs;
    private List<GameObject> _splatters;

    private bool _initilized;
    private float _lifetime;

    public void Init(Vector3 position, Vector3 direction, float force, float length)
    {
        _splatters = new List<GameObject>();
        _lifetime = length;
        _initilized = true;
        int splatters = Random.Range(MinSplatters, MaxSplatters);

        for (int i = 0; i < splatters; i++)
        {
            GameObject newSplatter = new GameObject("Blood");
            newSplatter.transform.SetParent(transform);
            newSplatter.transform.position = position;
            newSplatter.AddComponent<SpriteRenderer>().sprite =
                SplatterPrefabs[Random.Range(0, SplatterPrefabs.Length)];
            Vector3 dir = new Vector3(direction.x * Random.Range(0, 14), direction.y * Random.Range(0, 14));

            Rigidbody2D rb = newSplatter.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.velocity = dir.normalized * force;
            _splatters.Add(newSplatter);
        }
    }

    private void Update()
    {
        if (!_initilized)
            return;
        
        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0)
        {
            KillSplatters();
        }
    }

    private void KillSplatters()
    {
        foreach (GameObject splatter in _splatters)
        {
            Destroy(splatter);
        }
        gameObject.SetActive(false);
    }
}
