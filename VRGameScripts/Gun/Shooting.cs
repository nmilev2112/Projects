using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public float speed = 10;
    public GameObject bulletPrefab = null;
    public Transform barrel = null;
    private ProjectilePool projectilePool = null;
    

    private void Awake()
    {
        projectilePool = new ProjectilePool(bulletPrefab, 6);
    }

    public void PullTrigger()
    {
        Fire();
    }

    private void Fire()
    {
        Projectile tragetProjectile = projectilePool.projectiles[0];
        tragetProjectile.Launch(this);
    }
}