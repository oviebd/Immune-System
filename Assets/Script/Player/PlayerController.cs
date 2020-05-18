using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour ,IColliderEnter
{
    [SerializeField] private GameEnum.PlayerType _playerType = GameEnum.PlayerType.Type_1_Base;
    [SerializeField] private GameObject _playerGraphics;
    private IGunController _iGunController;
    private IHealth _playerHealth;
    private Collider2D _collider;
    private Explosion _explosion;

   
    private void Start()
    {
        _collider = this.gameObject.GetComponent<Collider2D>();
        _explosion = this.gameObject.GetComponent<Explosion>();
		GetIgunController().StartShooting();
	}


    public IGunController GetIgunController()
    {
        if (_iGunController == null)
            _iGunController = this.gameObject.GetComponent<IGunController>();
        return _iGunController;
    }

    public IHealth GetPlayerHealth()
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
        //Todo 
       //  Inactive all Enemy and other objs 
        GameEnvironmentController.instance.SetEnvironmentForPlayerDieMode();
        if (_playerGraphics != null)
            _playerGraphics.SetActive(false);
        if (_collider != null)
            _collider.enabled = false;

		GetIgunController().StopShooting();
       if ( _explosion != null)
            _explosion.Explode();

        Invoke("ActionAfterDie", 2.0f);
    }

    void ActionAfterDie()
    {
        GameActionHandler.instance.ActionGameOver(false);
    }
    public GameEnum.PlayerType GetPlayerType()
    {
        return _playerType;
    }
    public void SetPlayerType(GameEnum.PlayerType playerType)
    {
        _playerType = playerType;
    }
  
}
