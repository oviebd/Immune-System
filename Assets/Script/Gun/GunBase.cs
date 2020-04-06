using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
	[SerializeField] private GameEnum.GunType _gunType = GameEnum.GunType.GunType_1;
	[SerializeField]private GameObject _bulletObj;
	[SerializeField]private GameObject _parentObj;

	[SerializeField] private int   _maxBullet;
	[SerializeField] private float _coolDownTime;
	[SerializeField] private int   _damage;
	[SerializeField] private bool _infiniteFirePower = true;
	private float _lastShootTime ;


    private void Start()
    {
		_lastShootTime = Time.time;
	}

    public void InstantiateBullet()
	{
		if (CanShoot())
        {
			_lastShootTime = Time.time;
			GameObject bulletObj = InstantiatorHelper.instance.InstantiateObject(_bulletObj, _parentObj);
			ReduceBulletAmount();
		}
		
	}

    bool CanShoot()
    {
		if (_infiniteFirePower == false && _maxBullet <= 0)
			return false;
        //if (_maxBullet <= 0)
			//return false;
		if (IsCoolDownTimePassed() == true)
			return true;

		return false;
    }

    bool IsCoolDownTimePassed()
    {
		if (Time.time - _lastShootTime >= _coolDownTime)
			return true;
		else
			return false;
    }

    void ReduceBulletAmount()
    {
		_maxBullet = _maxBullet - 1;
		if (_maxBullet < 0)
			_maxBullet = 0;
	}
	public GameEnum.GunType GetGun()
	{
		return _gunType;
	}
	public void SetGunType(GameEnum.GunType gunType)
	{
		_gunType = gunType;
	}
}
