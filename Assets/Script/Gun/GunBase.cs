using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
	[SerializeField] private GameEnum.GunType _gunType = GameEnum.GunType.GunType_1;
	[SerializeField]private GameObject _bulletObj;
	[SerializeField]private GameObject _parentObj;
	
	//[SerializeField] private int   _maxBullet;
	//[SerializeField] private int   _damage;

	private bool _isItPrimaryGun = false;

	private GameObject _primarylBullet;

	private void Start()
    {
		_primarylBullet = _bulletObj;
	}


    public void InstantiateBullet()
	{
		GameObject bulletObj = InstantiatorHelper.instance.InstantiateObject(_bulletObj, _parentObj);
		//ReduceBulletAmount();
	}

    
   /* void ReduceBulletAmount()
    {
		_maxBullet = _maxBullet - 1;
		if (_maxBullet < 0)
			_maxBullet = 0;
	}*/
	public GameEnum.GunType GetGun()
	{
		return _gunType;
	}
	public void SetGunType(GameEnum.GunType gunType)
	{
		_gunType = gunType;
	}

	public bool IsItPrimaryGun()
	{
		return _isItPrimaryGun;
	}
	public void SetIsItPrimaryGun(bool isItPrimaryGun)
	{
	      _isItPrimaryGun = isItPrimaryGun;
	}

    public void UpdateBulletTemporarily(GameObject bulletGameObj,float duration)
    {
		_bulletObj = bulletGameObj;
		Invoke("SetNormalBullet", duration);
    }
    private void SetNormalBullet()
    {
		_bulletObj = _primarylBullet;
	}

    public BulletBase GetBulletBase()
    {
		return _bulletObj.GetComponent<BulletBase>();
	}

}
