using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float shotRate;
    private float remainingTimeToShoot;
    private bool canShoot = true;

    private void Update()
    {
        ShotCooldown();
        ShotInput();
    }

    private void ShotInput()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            Shoot();
            canShoot = false;
        }
    }

    private void Shoot()
    {
        GameObject newProjectile = Pool.instance.GetItemFromPool(projectile, shootOrigin.position, shootOrigin.transform.rotation);
        newProjectile.GetComponent<ProjectileBehaviour>().Initialize(projectileSpeed);
    }

    private void ShotCooldown()
    {
        if (!canShoot)
        {
            remainingTimeToShoot -= Time.deltaTime;
            if (remainingTimeToShoot <= 0)
            {
                canShoot = true;
                remainingTimeToShoot = shotRate;
            }
        }
    }
}
