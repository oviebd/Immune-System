using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourBase : MonoBehaviour, IColliderEnter
{
     protected GameObject _playerObj;
    [SerializeField] private GameObject graphicsObj;
    [SerializeField] Collider2D _collider;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private GameEnum.EnemyType _enemyType;
	protected Vector3 targetPos;
    private IENemyBehaviour _enemyBehaviour;
    private IHealth _health;
	[SerializeField]private IGunController _iGunController;
    private bool _isEnemyEnteredGameScene;

	public delegate void OnEnemyDestroyedByPlayer(EnemyBehaviourBase behaviour);
    public static event OnEnemyDestroyedByPlayer enemyDestroyedByPlayer;

    private void Start()
    {
        _isEnemyEnteredGameScene = false;
        SearchForPlayer();
        GetHealth();
    }

    public void SetEnemyBehaviour(IENemyBehaviour behaviour)
    {
        this._enemyBehaviour = behaviour;
    }

    void SearchForPlayer()
    {
        PlayerController controller = FindObjectOfType<PlayerController>();

        if (controller != null)
        {
            _playerObj = controller.gameObject;

            IENemyBehaviour behaviour = this.gameObject.GetComponent<IENemyBehaviour>();

            if (behaviour != null)
                behaviour.OnTargetFound(_playerObj);
        }
    }

	public GameEnum.EnemyType GetEnemyType()
	{
		return _enemyType;
	}

	public void onCollide(GameObject collidedObject)
    {
		//Debug.Log("Is enemy ENtered ; " + this._isEnemyEnteredGameScene + gameObject.name);
		//  if ( this._isEnemyEnteredGameScene == true && GetHealth() != null && collidedObject.GetComponent<DamageAble>() != null)
		if ( GetHealth() != null && collidedObject.GetComponent<DamageAble>() != null)
		{
			DamageAble damageAble = collidedObject.GetComponent<DamageAble>();
            GetHealth().ReduceHealth(damageAble.GetDamage());
            if (GetHealth().IsDie())
				Die(collidedObject);
        }
    }

    void Die(GameObject collidedObject)
    {
		ScoreManager.instance.AddScore(GetRewardPoint());
		DestroyObj();
		enemyDestroyedByPlayer(this);
    }

    void DestroyObj()
    {
        if( _enemyBehaviour!= null)
        {
            if (_explosion != null)
                _explosion.Explode();

            _enemyBehaviour.OnDestroyObject();
        }
		SetInactiveMode();
		Destroy(this.gameObject, 2.0f);
	}

    public void SetInactiveMode()
    {
        _collider.enabled = false;
        graphicsObj.SetActive(false);
        Utils.StopMovementOf_A_IMove_Gameobject(this.gameObject);
		if (GetGunController() != null)
		{
			GetGunController().StopShooting();
		}
			
	}

	public void SetActiveMode()
	{
		_collider.enabled = true;
		graphicsObj.SetActive(true);
		Utils.StartMovementOf_A_IMove_Gameobject(this.gameObject);

        if (GetGunController() != null && _isEnemyEnteredGameScene == true)
		{
			GetGunController().StartShooting();
		}
	}
	public int GetRewardPoint()
    {
        if (gameObject.GetComponent<IReward>() != null)
           return gameObject.GetComponent<IReward>().GetReward();
        return 0;
    }

	
    public IGunController GetGunController()
	{
		if (_iGunController == null)
			_iGunController = this.gameObject.GetComponent<IGunController>();
		return _iGunController;
	}
    IHealth GetHealth()
    {
        if (_health == null) 
            _health = this.GetComponent<Health>();
        return _health;
    }

	public void StopMovement()
	{

	}
    public void SetIsEnemyEnteredGameSceneValue(bool isEntered)
    {
        _isEnemyEnteredGameScene = isEntered;
    }

}
