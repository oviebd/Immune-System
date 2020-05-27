using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
	[SerializeField] private GameEnum.GunType _gunType = GameEnum.GunType.GunType_1;
	[SerializeField]private GameObject _bulletPrefab;
	[SerializeField]private GameObject _parentObj;

	private bool _isItPrimaryGun = false;

	private GameObject _primarylBullet;
	private GameObject _currentBulletObj;

	private void Start()
    {
		_primarylBullet = _bulletPrefab;
	}

    public GameObject InstantiateBullet()
	{
		_currentBulletObj = InstantiatorHelper.instance.InstantiateObject(_bulletPrefab, GetParentObj());
		return _currentBulletObj;
	}

    private GameObject GetParentObj()
    {
		if (_parentObj == null)
			_parentObj = this.gameObject;

		return _parentObj;
    }
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
		_bulletPrefab = bulletGameObj;
		Invoke("SetNormalBullet", duration);
    }
    private void SetNormalBullet()
    {
		_bulletPrefab = _primarylBullet;
	}

    public BulletBase GetBulletBase()
    {
		if(_currentBulletObj  != null )
			return _currentBulletObj.GetComponent<BulletBase>();
		return null;
	}

}
