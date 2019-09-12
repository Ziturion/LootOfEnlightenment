using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BloodPool : MonoBehaviour
{
    public static BloodPool Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            _instance = FindObjectOfType<BloodPool>();
            return _instance;
        }
    }

    private static BloodPool _instance;

    public BloodSplatter BloodPrefab;
    public int PoolSize = 200;

    private List<BloodSplatter> _allBlood = new List<BloodSplatter>();
    private List<BloodSplatter> _allActiveBlood = new List<BloodSplatter>();

    void Start()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            BloodSplatter newProjectile = Instantiate(BloodPrefab, transform);
            newProjectile.gameObject.SetActive(false);
            _allBlood.Add(newProjectile);
        }
    }

    public void SpawnBloodSplatter(Vector3 position, Vector3 direction, float force, float length)
    {
        BloodSplatter blood = _allBlood.First();
        blood.transform.Rotate(Vector3.forward, Vector2.SignedAngle(Vector2.up, direction));
        blood.transform.position = position;
        blood.gameObject.SetActive(true);
        blood.Init(position,direction, force, length);
        _allBlood.Remove(blood);
        _allActiveBlood.Add(blood);
    }

    void Update()
    {
        for (int i = _allActiveBlood.Count - 1; i >= 0; i--)
        {
            BloodSplatter activeBlood = _allActiveBlood[i];

            if (!activeBlood.gameObject.activeSelf)
            {
                activeBlood.transform.rotation = Quaternion.identity;
                _allBlood.Add(activeBlood);
                _allActiveBlood.Remove(activeBlood);
            }
        }
    }
}