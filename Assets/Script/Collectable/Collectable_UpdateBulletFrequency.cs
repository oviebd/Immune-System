using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_UpdateBulletFrequency : CollectableBase,ICollectable
{
    [SerializeField] float _duration = 10.0f;

    private void Start()
    {
        SetCollectable(this);
    }

    public void ExecuteCollectableEffect()
    {
        List<IGun> gunList = GetPlayerGunList();
        if (gunList != null)
        {
            for (int i = 0; i < gunList.Count; i++)
            {
                gunList[i].UpdateWeaponBulletFrequencyTemporarily(_duration);
            }
        }
    }

    
}
