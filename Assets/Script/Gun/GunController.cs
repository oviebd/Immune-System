using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] private List<GameObject> _guns;
	[SerializeField] private bool _isAutomaticFire = false;
	[SerializeField] private bool _isEnemyGun = false;

    [SerializeField] private int _minActiveGunNum = 1;
    private List<IGun> _iGunList = new List<IGun>();
	private int currentActiveGunNumber = 0;

	[SerializeField] private int _maxBullet;
	[SerializeField] private bool _infiniteFirePower = true;
	[SerializeField] private float _coolDownTime = .3f;

    private float _lastShootTime;
	private float _primaryCoolDownTime;

	void Start()
    {
		_lastShootTime = Time.time;
		_primaryCoolDownTime = _coolDownTime;

		if (_isEnemyGun)
			SetGuns();	
		//if (_isAutomaticFire == false)
			//InputManager.onShootButtonPressed += onGunButtonPressed;
	}



	#region GunSetUp

	public List<IGun> GetIGunList()
	{
		return _iGunList;
	}

	public void InstantiateGun(GameObject gunPrefab)
	{
		for (int i = 0; i < _guns.Count; i++)
		{
			GameObject newObj = Instantiate(gunPrefab, _guns[i].transform);
			newObj.transform.parent = _guns[i].transform;
			AppendGunObjectInCoreGunList(newObj, i);
		}
	}
	private void SetGuns()
    {
		for (int i = 0; i < _guns.Count; i++)
        {
			AppendGunObjectInCoreGunList(_guns[i], i);
		}
	}

    private void AppendGunObjectInCoreGunList(GameObject gun, int i)
    {
		if (gun.GetComponent<IGun>() != null)
		{
			IGun iGun = gun.gameObject.GetComponent<IGun>();
			_iGunList.Add(iGun);

			if (_isEnemyGun == true)
				return;
			//Execute for only Player Gun
			if ( i < _minActiveGunNum)
			{
				_iGunList[i].SetIsItPrimaryGun(true);
				currentActiveGunNumber = currentActiveGunNumber + 1;
			}
			else
				_iGunList[i].SetIsItPrimaryGun(false);

			_iGunList[i].SetShootingCapabilities(_iGunList[i].IsItPrimaryGun());
		}
	}

    #endregion GunSetUp

    #region UpdateGun

    public void AddGun()
    {
		currentActiveGunNumber = currentActiveGunNumber + 1;

        if (currentActiveGunNumber > _iGunList.Count)
        {
			currentActiveGunNumber = currentActiveGunNumber - 1;
			return;
		}

        if(currentActiveGunNumber == 2 && _iGunList.Count >= 3)
        {
			_iGunList[0].SetShootingCapabilities(false);
			_iGunList[1].SetShootingCapabilities(true);
			_iGunList[2].SetShootingCapabilities(true);

			return;
		}

        for(int i = 0; i < currentActiveGunNumber; i++)
        {
			_iGunList[i].SetShootingCapabilities(true);

		}
    }

	public void RemoveGun()
	{
		currentActiveGunNumber = currentActiveGunNumber - 1;
        if(currentActiveGunNumber == 2 && _iGunList.Count >= 3)
        {
			_iGunList[0].SetShootingCapabilities(false);
			_iGunList[1].SetShootingCapabilities(true);
			_iGunList[2].SetShootingCapabilities(true);

			return;
		}

        if(currentActiveGunNumber <= _minActiveGunNum)
        {
            for(int i=0;i< _iGunList.Count; i++)
            {
				_iGunList[i].SetShootingCapabilities(_iGunList[i].IsItPrimaryGun());
            }
			currentActiveGunNumber = _minActiveGunNum;
			return;
		}

		_iGunList[currentActiveGunNumber].SetShootingCapabilities(false);
	}
    
	public void UpdateWeaponBulletFrequencyTemporarily(float duration)
	{
		_coolDownTime = (_coolDownTime - (_coolDownTime / 2));
		Invoke("SetNormalCoolDowntime", duration);
	}
	private void SetNormalCoolDowntime()
	{
		_coolDownTime = _primaryCoolDownTime;
	}

	#endregion UpdateGun


	#region Shooting

    public void Shoot()
	{
		if (_isAutomaticFire == true)
			onGunButtonPressed();
	}
	private void Update()
	{
        if (Utils.CanSpawnThings())
			Shoot();
	}
	private void onGunButtonPressed()
	{
		if (CanShoot() == true)
		{
			for (int i = 0; i < _iGunList.Count; i++)
			{
				IGun gun = _iGunList[i];
				gun.Shoot();
			}
			_lastShootTime = Time.time;
		}

	}
	private bool CanShoot()
	{
		if (_infiniteFirePower == false && _maxBullet <= 0)
			return false;
		//if (_maxBullet <= 0)
		//return false;
		if (IsCoolDownTimePassed() == true)
			return true;

		return false;
	}
	private bool IsCoolDownTimePassed()
	{
		if (Time.time - _lastShootTime >= _coolDownTime)
			return true;
		else
			return false;
	}
	#endregion Shooting
}
