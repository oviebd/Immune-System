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
    }
	public void Run()
	{
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
       if (_target != null)
            MoveTowards();
    }

    private void MoveTowards()
    {
        if (_canMove == true)
        {
            if (MathHandler.IsExceedMinimumDistance(_target.transform.position, transform.position, _stoppingDistance) == false)
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
                }
            }
        }
    }

    void SetMovement()
    {
        OnGoingCompleted.Invoke();
    }

    public void StopMovement()
    {
        _canMove = false;
    }
}
