using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveTowardsATarget : MonoBehaviour,IMove
{
    public UnityEvent OnGoingCompleted;

    [SerializeField] private Transform _target;
    [SerializeField] private float _movingSpeed = 1.0f;
	[SerializeField] private float _stoppingDistance = 0.0f;
    Vector3 targetPos ;
    bool isReachedDestination = false;
    float _angle;
    public void Setup(Transform target,float distance)
    {
        this._target = target;
       // targetPos = target.transform.position;
		this._stoppingDistance = distance;
        ReSetTarget();
    }

    void Update()
    {
        MoveTowards();
    }

    private void MoveTowards()
    {
        if(targetPos != null)
        {
            if (MathHandler.IsExceedMinimumDistance(targetPos, transform.position, 0))
			{
				float step = _movingSpeed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            }
            else
            {
                if (isReachedDestination == false)
                {
                    isReachedDestination = true;
                    Invoke("SetMovement", .5f);
                    // if (OnGoingCompleted != null)

                }
               
            }
        }
    }

    void SetMovement()
    {
        //OnGoingCompleted.Invoke(0.5f);
        FindObjectOfType<OrbitingTowardsATarget>().SetMoveAble(_angle);
    }

    void ReSetTarget()
    {
         _angle = MathHandler.GetAngle(_target, transform); // In Degree
        Debug.Log(" Angle degree : " + _angle);
        _angle = _angle * Mathf.Deg2Rad;
        Debug.Log(" Angle rad : " + _angle);
        float _posX = Mathf.Cos(_angle) * _stoppingDistance;
        float _posY = Mathf.Sin(_angle) * _stoppingDistance;

        targetPos = new Vector2(_posX, _posY);
        Debug.Log(targetPos);
        // _target.transform.position = new Vector2(_posX, _posY);

    }

	
}
