using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunController
{
	List<IGun> GetGuns();
	void AppendGunsInGunController(IGun gun, int i);
	void StopShooting();
	void StartShooting();
	void StartShooting(float waitingTime);
	void UpdateCooldownTimeTeporarily(float cooldownTime);
}
    

