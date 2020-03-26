using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] private List<GameObject> _guns;
	[SerializeField] private bool isItEnemyGun = false;

	private int _activeGunNum = 0;
    private List<IGun> _iGunList = new List<IGun>();

    void Start()
    {
		GetCoreGunComponent();

		if (isItEnemyGun == false)
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


    void GetCoreGunComponent()
    {
        if(_guns != null && _guns.Count > 0)
        {
			_iGunList.Clear();

            for (int i = 0; i < _guns.Count; i++)
			{
				 GameObject gun = _guns[i];
                if(gun.GetComponent<IGun>() != null)
                {
					IGun iGun = gun.gameObject.GetComponent<IGun>();
					_iGunList.Add(iGun);

                    if(i == 0)
                    {
						_iGunList[i].SetShootingCapabilities(true);
						_activeGunNum = 1;
					}
                    else
						_iGunList[i].SetShootingCapabilities(false);
					
				}
			}
		}
    }

    void onGunButtonPressed()
	{
		for(int i=0; i< _iGunList.Count; i++)
		{
			IGun gun = _iGunList[i];
			gun.Shoot();
		}
	}

    public void AddGun()
    {
        if( (_activeGunNum + 1) <= _iGunList.Count )
        {
			_iGunList[_activeGunNum].SetShootingCapabilities(true);
			_activeGunNum = _activeGunNum + 1;
		}
    }

	public void RemoveGun()
	{
		if ((_activeGunNum ) <= _iGunList.Count)
		{
			_iGunList[_activeGunNum -1 ].SetShootingCapabilities(false);
			_activeGunNum = _activeGunNum - 1;
		}
	}

}
