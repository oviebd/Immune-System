using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : GunControllerBase,IGunController
{
	[SerializeField] private int _minActiveGunNum = 1;
	
	private List<IGun> _iGunList = new List<IGun>();
	private int currentActiveGunNumber = 0;
	private float _primaryCoolDownTime;

	private void Awake()
	{
		PlayerUpdateController.onPlayerSystemUpdate += OnGunSystemUpdate;
		SetGunController(this);
		_primaryCoolDownTime = _coolDownTime;
	}
	private void OnDestroy()
	{
		PlayerUpdateController.onPlayerSystemUpdate -= OnGunSystemUpdate;
	}
	public void AppendGunsInGunController(IGun iGun, int i)
	{
		if( i < _minActiveGunNum)
		{
			iGun.SetIsItPrimaryGun(true);
			currentActiveGunNumber = currentActiveGunNumber + 1;
		}
		else
			iGun.SetIsItPrimaryGun(false);

		iGun.SetShootingCapabilities(iGun.IsItPrimaryGun());
		_iGunList.Add(iGun);
	}

	private void OnGunSystemUpdate(GameEnum.UpgradeType updateType)
	{
		if (updateType == GameEnum.UpgradeType.AddGun)
			AddGun();
		else if (updateType == GameEnum.UpgradeType.RemoveGun)
			RemoveGun();
	}

	
	public List<IGun> GetGuns()
	{
		if (_iGunList == null)
			_iGunList = new List<IGun>();
		return _iGunList;
	}

	public void UpdateCooldownTimeTeporarily(float duration)
	{
		_coolDownTime = (_coolDownTime - (_coolDownTime / 2));
		UpdateCooldownTime(_coolDownTime);
		Invoke("SetNormalCoolDowntime", duration);
	}

	private void SetNormalCoolDowntime()
	{
		_coolDownTime = _primaryCoolDownTime;
		UpdateCooldownTime(_coolDownTime);
	}

	#region UpdateGun
	private void AddGun()
	{
		currentActiveGunNumber = currentActiveGunNumber + 1;

		if (currentActiveGunNumber > _iGunList.Count)
		{
			currentActiveGunNumber = currentActiveGunNumber - 1;
			return;
		}

		if (currentActiveGunNumber == 2 && _iGunList.Count >= 3)
		{
			_iGunList[0].SetShootingCapabilities(false);
			_iGunList[1].SetShootingCapabilities(true);
			_iGunList[2].SetShootingCapabilities(true);

			return;
		}

		for (int i = 0; i < currentActiveGunNumber; i++)
		{
			_iGunList[i].SetShootingCapabilities(true);

		}
	}
	private void RemoveGun()
	{
		currentActiveGunNumber = currentActiveGunNumber - 1;
		if (currentActiveGunNumber == 2 && _iGunList.Count >= 3)
		{
			_iGunList[0].SetShootingCapabilities(false);
			_iGunList[1].SetShootingCapabilities(true);
			_iGunList[2].SetShootingCapabilities(true);

			return;
		}

		if (currentActiveGunNumber <= _minActiveGunNum)
		{
			for (int i = 0; i < _iGunList.Count; i++)
			{
				_iGunList[i].SetShootingCapabilities(_iGunList[i].IsItPrimaryGun());
			}
			currentActiveGunNumber = _minActiveGunNum;
			return;
		}

		_iGunList[currentActiveGunNumber].SetShootingCapabilities(false);
	}
	#endregion UpdateGun

}
