using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunType1 : GunBase,IGun
{
    [SerializeField] private bool _canShoot = false;

    public void SetShootingCapabilities(bool canShoot)
    {
        this._canShoot = canShoot;
    }

    public void Shoot()
    {
        if(_canShoot)
            InstantiateBullet();
    }
}
