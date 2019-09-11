using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            _instance = FindObjectOfType<ProjectilePool>();
            return _instance;
        }
    }

    private static ProjectilePool _instance;

    public Projectile ProjectilePrefab;
    public int PoolSize = 200;

    private List<Projectile> _allProjectiles = new List<Projectile>();
    private List<Projectile> _allActiveProjectiles = new List<Projectile>();

    void Start()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            Projectile newProjectile = Instantiate(ProjectilePrefab, transform);
            newProjectile.gameObject.SetActive(false);
            _allProjectiles.Add(newProjectile);
        }
    }

    public void SpawnProjectile(Vector3 position, Vector3 direction, float damage, float speed)
    {
        Projectile newProjectile = _allProjectiles.First();
        _allProjectiles.Remove(newProjectile);
        _allActiveProjectiles.Add(newProjectile);
        newProjectile.transform.position = position;
        newProjectile.gameObject.SetActive(true);
        newProjectile.Init(direction, damage, speed);
    }

    void Update()
    {
        foreach (Projectile activeProjectile in _allActiveProjectiles)
        {
            if (!activeProjectile.enabled)
            {
                _allActiveProjectiles.Remove(activeProjectile);
                _allProjectiles.Add(activeProjectile);
            }
        }
    }
}
