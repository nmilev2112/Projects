﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public List<T> Create<T>(GameObject prefab, int count)
        where T : MonoBehaviour
    {
        List<T> newPool = new List<T>();

        for(int i = 0; i < count; i++)
        {
            GameObject projectileObject = GameObject.Instantiate (prefab, Vector3.zero, Quaternion.identity);
            T newProjectile = projectileObject.GetComponent<T>();

            newPool.Add(newProjectile);
        }

        return newPool;
    }
}

public class ProjectilePool : Pool
{
    public List<Projectile> projectiles = new List<Projectile>();

    public ProjectilePool(GameObject prefab, int count)
    {
        projectiles = Create<Projectile>(prefab, count);
    }

    public void SetAllProjectiles(bool value)
    {
        foreach(Projectile projectile in projectiles)
        {
            projectile.SetInnactive();
        }
    }
}