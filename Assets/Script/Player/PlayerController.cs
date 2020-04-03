using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour ,IColliderEnter
{
	private PlayerLevelData _playerLevelData;
    private GunController _gunControllere;
    private IHealth _playerHealth;

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

    private IHealth GetPlayerHealth()
    {
        if (_playerHealth == null)
            _playerHealth = this.GetComponent<IHealth>();
        return _playerHealth;
    }

    public void onCollide(GameObject collidedObj)
    {
        if (collidedObj.GetComponent<DamageAble>())
        {
            DamageAble damage = collidedObj.GetComponent<DamageAble>();
            GetPlayerHealth().ReduceHealth(damage.GetDamage());
            if (GetPlayerHealth().IsDie())
                PlayerDie();
            Debug.Log("Player Health : " + GetPlayerHealth().GetHealthAmount());
        }
    }

    void PlayerDie()
    {
        Debug.Log("Platyer Die");
    }
}
