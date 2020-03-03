using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveTowardsATarget : MonoBehaviour,IMove
{
    public UnityEvent OnGoingCompleted;

	[SerializeField] private float _movingSpeed = 1.0f;
	[SerializeField] private float _stoppingDistance = 0.0f;
    private Vector3 _targetPos ;

	bool isReachedDestination = false;
	private bool _canMove = false;
    float _angle;


	public void Setup(Vector3 target,float distance)
    {
		_targetPos = target;
		this._stoppingDistance = distance;
     //   ReSetTarget();
    }
	public void Run()
	{
		if(_targetPos != null)
			_canMove = true;
	}

	public void SetTargetTransform(Transform targetTransform)
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
        if(_canMove == true)
        {
            if (MathHandler.IsExceedMinimumDistance(_targetPos, transform.position, 0))
			{
				float step = _movingSpeed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, _targetPos, step);
            }
            else
            {
                if (isReachedDestination == false)
                {
                    isReachedDestination = true;
                  //  Invoke("SetMovement", .5f);
					if (OnGoingCompleted != null)
						SetMovement();

					this.enabled = false;
					
                }
               
            }
        }
    }

    void SetMovement()
    {
        OnGoingCompleted.Invoke();
       // FindObjectOfType<OrbitingTowardsATarget>().SetMoveAble(_angle);
    }
	
}
