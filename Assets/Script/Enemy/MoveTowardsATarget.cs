using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveTowardsATarget : MonoBehaviour,IMove
{
    public UnityEvent OnGoingCompleted;

	[SerializeField] private float _movingSpeed = 1.0f;
	[SerializeField] private float _stoppingDistance = 0.0f;
    private GameObject _target ;

	bool isReachedDestination = false;
	private bool _canMove = false;

	public void Setup(GameObject targetObj,float distance)
    {
        _target = targetObj;
		//this._stoppingDistance = distance;
    }
	public void Run()
	{
		if(_target != null)
			_canMove = true;
	}

	public void SetTargetObject(GameObject targetObject)
	{
	}
	public void SetAngle(float angle)
	{
	}
	void Update()
    {
        MoveTowards();
    }

    private void MoveTowards()
    {
        if (_canMove == true)
        {
            if (MathHandler.IsExceedMinimumDistance(_target.transform.position, transform.position, _stoppingDistance))
			{
				float step = _movingSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
            }
            else
            {
                if (isReachedDestination == false)
                {
                    isReachedDestination = true;
					if (OnGoingCompleted != null)
						SetMovement();
					//this.enabled = false;
                }
            }
        }
    }

    void SetMovement()
    {
        OnGoingCompleted.Invoke();
       // FindObjectOfType<OrbitingTowardsATarget>().SetMoveAble(_angle);
    }

    public void StopMovement()
    {
        _canMove = false;
    }
}
