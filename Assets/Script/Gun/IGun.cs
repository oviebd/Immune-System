using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    void Shoot();
    void SetShootingCapabilities(bool canShoot);
	bool IsItPrimaryGun();
    void SetIsItPrimaryGun(bool isItPrimaryGun);
    void UpdateWeaponBulletFrequencyTemporarily(float duration);
    void UpdateBulletTemporarily(GameObject bulletGameObj, float duration);
}
