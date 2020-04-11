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

    public delegate void OnEnemyDestroyedByPlayer(EnemyBehaviourBase behaviour);
    public static event OnEnemyDestroyedByPlayer enemyDestroyedByPlayer;

    private void Start()
    {
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
            graphicsObj.SetActive(true);
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
        if (GetHealth() != null && collidedObject.GetComponent<DamageAble>() != null)
        {
            DamageAble damageAble = collidedObject.GetComponent<DamageAble>();
            GetHealth().ReduceHealth(damageAble.GetDamage());
            if (GetHealth().IsDie())
                Die();
        }
    }

    void Die()
    {
        DestroyObj();
        enemyDestroyedByPlayer(this);
    }

    void DestroyObj()
    {
        SetInactiveMode();
        Destroy(this.gameObject, 2.0f);

        if( _enemyBehaviour!= null)
        {
            if (_explosion != null)
                _explosion.Explode();

            _enemyBehaviour.OnDestroyObject();
        }
        ScoreManager.instance.AddScore(GetRewardPoint());
    }

    public void SetInactiveMode()
    {
        _collider.enabled = false;
        graphicsObj.SetActive(false);
        Utils.StopMovementOf_A_IMove_Gameobject(this.gameObject);
    }

    public int GetRewardPoint()
    {
        if (gameObject.GetComponent<IReward>() != null)
           return gameObject.GetComponent<IReward>().getRewardPoint();
        return 0;
    }

    IHealth GetHealth()
    {
        if (_health == null)
            _health = this.GetComponent<Health>();
        return _health;
    }

}
