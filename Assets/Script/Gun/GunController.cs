using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] private List<GameObject> _guns;
	[SerializeField] private bool _isAutomaticFire = false;
	[SerializeField] private bool _isEnemyGun = false;

   [SerializeField] private int _minActiveGunNum = 1;
	private int _lastGunIndex = 0; 
    private List<IGun> _iGunList = new List<IGun>();

    void Start()
    {
		if (_isEnemyGun)
			SetGuns();	
		//if (_isAutomaticFire == false)
			//InputManager.onShootButtonPressed += onGunButtonPressed;
	}
    public void Shoot()
    {
		if (_isAutomaticFire == true)
			onGunButtonPressed();
	}

    private void SetGuns()
    {
		for (int i = 0; i < _guns.Count; i++)
        {
			AppendGunObjectInCoreGunList(_guns[i], i);
		}
	}

    public void InstantiateGun(GameObject gunPrefab)
    {
        for(int i = 0; i < _guns.Count; i++)
        {
			GameObject newObj = Instantiate(gunPrefab, _guns[i].transform);
			newObj.transform.parent = _guns[i].transform;
			AppendGunObjectInCoreGunList(newObj, i);
		}
	}

    void AppendGunObjectInCoreGunList(GameObject gun, int i)
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
				_lastGunIndex = i;
			}
			else
				_iGunList[i].SetIsItPrimaryGun(false);

			_iGunList[i].SetShootingCapabilities(_iGunList[i].IsItPrimaryGun());
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
		if ( (_lastGunIndex  + 1 ) < _iGunList.Count )
        {
			_iGunList[_lastGunIndex + 1 ].SetShootingCapabilities(true);
			_lastGunIndex = _lastGunIndex + 1;
		}
    }

	public void RemoveGun()
	{
		if( (_lastGunIndex ) > 0 &&  _iGunList[_lastGunIndex  ].IsItPrimaryGun() == false)
		{
			_iGunList[_lastGunIndex].SetShootingCapabilities(false);
			_lastGunIndex = _lastGunIndex - 1;
		}
	}

}
