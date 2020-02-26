using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] private List<GunBase> gunList;
	[SerializeField] private bool isItEnemyGun = false;

    void Start()
    {
        if(isItEnemyGun == false)
			InputManager.onShootButtonPressed += onGunButtonPressed;

	}
    private void OnDestroy()
    {
		if (isItEnemyGun == false)
			InputManager.onShootButtonPressed -= onGunButtonPressed;
	}

    public void Shoot()
    {
		if (isItEnemyGun == true)
			onGunButtonPressed();
	}

    void onGunButtonPressed()
	{
		for(int i=0; i<gunList.Count; i++)
		{
			IGun gun = gunList[i];
			gun.InstantiateBullet();
		}
	}


}
