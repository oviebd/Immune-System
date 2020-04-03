﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IColliderEnter
{
	private PlayerLevelData _playerLevelData;
	[SerializeField] private GunController _gunControllere;

    private void Awake()
    {
        PlayerUpdateController.onPlayerSystemUpdate += OnPlayerUpdateSystemSTatus;
    }
    private void OnDestroy()
    {
        PlayerUpdateController.onPlayerSystemUpdate -= OnPlayerUpdateSystemSTatus;
    }

    void OnPlayerUpdateSystemSTatus(GameEnum.UpgradeType upgradeType)
    {
        if (getGunController() == null)
            return;

        switch (upgradeType)
        {
            case GameEnum.UpgradeType.AddGun:
                getGunController().AddGun();
                break;
            case GameEnum.UpgradeType.RemoveGun:
                getGunController().RemoveGun();
                break;
        }
    }

    private void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        getGunController().Shoot();
    }

    public void SetPlayerLevelData(PlayerLevelData data)
    {
		this._playerLevelData = data;
    }
    public void InstantiateGun(GameObject gunPrefab)
    {
        if (getGunController() != null && gunPrefab != null)
            _gunControllere.InstantiateGun(gunPrefab);
    }

    private GunController getGunController()
    {
        if (_gunControllere == null)
            _gunControllere = this.gameObject.GetComponent<GunController>();

        return _gunControllere;
    }

    public void onCollide(GameObject collidedObj)
    {
        Destroy(collidedObj);
    }
}