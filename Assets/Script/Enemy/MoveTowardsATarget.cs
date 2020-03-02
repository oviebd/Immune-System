using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsATarget : MonoBehaviour,IMove
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _movingSpeed = 1.0f;
	[SerializeField] private float _stoppingDistance = 0.0f;
 
    public void Setup(Transform target,float distance)
    {
        this._target = target;
		this._stoppingDistance = distance;
    }

    void Update()
    {
        MoveTowards();
    }

    private void MoveTowards()
    {
        if(_target!= null)
        {
			if (MathHandler.IsExceedMinimumDistance(_target, transform, _stoppingDistance))
			{
				float step = _movingSpeed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
			}
        }
    }

	
}
