﻿using System.Collections;
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
        if (GetPlayerControler().getGunController() !=null )
        {
            GetPlayerControler().getGunController().UpdateWeaponBulletFrequencyTemporarily(_duration);
        }
    }
}
