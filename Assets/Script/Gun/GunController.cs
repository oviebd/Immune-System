using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] private List<GunBase> gunList;
    void Start()
    {
		InputManager.onShootButtonPressed += onGunButtonPressed;
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
