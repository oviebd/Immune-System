using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{

	[SerializeField]private GameObject _bulletObj;
	[SerializeField]private GameObject _parentObj;

	[SerializeField] private int   _maxBullet;
	[SerializeField] private float _coolDownTime;
	[SerializeField] private int   _damage;
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
			GameObject bulletObj = InstantiatorHelper.InstantiateObject(_bulletObj, _parentObj);
			ReduceBulletAmount();
		}
		
	}

    bool CanShoot()
    {
        if (_maxBullet <= 0)
			return false;
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
}
