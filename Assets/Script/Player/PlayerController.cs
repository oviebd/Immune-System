using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour ,IColliderEnter
{
    [SerializeField] private GameEnum.PlayerShipType _playerType = GameEnum.PlayerShipType.PlayerType_1;
    [SerializeField] private GameObject _playerGraphics;
    private PlayerLevelData _playerLevelData;
    private GunController _gunControllere;
    private IHealth _playerHealth;
    private Collider2D _collider;
    private Explosion _explosion;
   

    private void Awake()
    {
        PlayerUpdateController.onPlayerSystemUpdate += OnPlayerUpdateSystemSTatus;
    }
    private void OnDestroy()
    {
        PlayerUpdateController.onPlayerSystemUpdate -= OnPlayerUpdateSystemSTatus;
    }
    private void Start()
    {
        _collider = this.gameObject.GetComponent<Collider2D>();
        _explosion = this.gameObject.GetComponent<Explosion>();
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
        }
    }
    void PlayerDie()
    {
        if (_playerGraphics != null)
            _playerGraphics.SetActive(false);
        if (_collider != null)
            _collider.enabled = false;
     
        _explosion.Explode();
       if ( _explosion != null)
            _explosion.Explode();

        Invoke("ActionAfterDie", 2.0f);
    }

    void ActionAfterDie()
    {
        GameActionHandler.instance.ActionGameOver(false);
    }
    public GameEnum.PlayerShipType GetPlayerType()
    {
        return _playerType;
    }
    public void SetPlayerType(GameEnum.PlayerShipType playerType)
    {
        _playerType = playerType;
    }

}
