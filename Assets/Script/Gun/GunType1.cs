using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunType1 : GunBase,IGun
{

    public void Shoot()
    {
        InstantiateBullet();
    }

}
