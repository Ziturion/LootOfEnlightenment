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
        newProjectile.transform.Rotate(Vector3.forward, Vector2.SignedAngle(Vector2.up, direction));
        newProjectile.transform.position = position;
        newProjectile.gameObject.SetActive(true);
        newProjectile.Init(direction, damage, speed);
        _allProjectiles.Remove(newProjectile);
        _allActiveProjectiles.Add(newProjectile);
    }

    void Update()
    {
        for (int i = _allActiveProjectiles.Count - 1; i >= 0; i--)
        {
            Projectile activeProjectile = _allActiveProjectiles[i];

            if (!activeProjectile.gameObject.activeSelf)
            {
                activeProjectile.transform.rotation = Quaternion.identity;
                _allProjectiles.Add(activeProjectile);
                _allActiveProjectiles.Remove(activeProjectile);
            }
        }
    }
}