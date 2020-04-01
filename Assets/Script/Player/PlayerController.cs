using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IColliderEnter
{

	private PlayerLevelData _playerLevelData;
	[SerializeField] private GunController _gunControllere;

    void Start()
    {
		//InputManager.onRotationInputButtonPressed += SetRotation;
		onLoadLevel();
    }

	private void OnDestroy()
	{
		//InputManager.onRotationInputButtonPressed -= SetRotation;
	}

	void onLoadLevel()
    {
		_playerLevelData = LevelDataHandler.instance.GetPlayerLevelData(0);
		if (_playerLevelData != null)
			_gunControllere.InstantiateGun(_playerLevelData.playerGunPrefab);
    }

	public void onCollide(GameObject collidedObj)
	{
		Destroy(collidedObj);
	}
}
