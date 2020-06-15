using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_UpdateBullet : CollectableBase,ICollectable
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _duration = 10.0f;

    void Start()
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
                gunList[i].UpdateBulletTemporarily(_bulletPrefab,_duration);
            }
        }
    }

   
}
