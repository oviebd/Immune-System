using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : GunControllerBase, IGunController
{
	 private List<IGun> _iGunList = new List<IGun>();

	private void Awake()
	{
		SetGunController(this);
	}

	public void AppendGunsInGunController(IGun gun, int i)
	{
		gun.SetIsItPrimaryGun(true);
		gun.SetShootingCapabilities(true);
		_iGunList.Add(gun);
	}

	public List<IGun> GetGuns()
	{
		return _iGunList;
	}

	public void UpdateCooldownTimeTeporarily(float cooldownTime)
	{
		
	}
}
