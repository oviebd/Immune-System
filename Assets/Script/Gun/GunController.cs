using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] private List<GameObject> _guns;
	[SerializeField] private bool _isAutomaticFire = false;
	[SerializeField] private bool _isEnemyGun = false;

	private int _activeGunNum = 0;
    private List<IGun> _iGunList = new List<IGun>();

    void Start()
    {

		if (_isEnemyGun)
			SetGuns();
		//if (_isAutomaticFire == false)
			//InputManager.onShootButtonPressed += onGunButtonPressed;
	}

    private void OnDestroy()
    {
		//if (_isAutomaticFire == false)
			//InputManager.onShootButtonPressed -= onGunButtonPressed;
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
			GameObject newObj = Instantiate(gunPrefab, _guns[i].transform.position, gunPrefab.transform.rotation);
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
			// Execute for only Player Gun
			if (i == 0)
			{
				_iGunList[i].SetShootingCapabilities(true);
				_activeGunNum = 1;
			}
			else
				_iGunList[i].SetShootingCapabilities(false);
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
		if (_activeGunNum == 1)  // Oonly 1 gun is enabled . So It can not be removed .
			return; 
		if ((_activeGunNum ) <= _iGunList.Count )
		{
			_iGunList[_activeGunNum -1 ].SetShootingCapabilities(false);
			_activeGunNum = _activeGunNum - 1;
		}
	}

}
