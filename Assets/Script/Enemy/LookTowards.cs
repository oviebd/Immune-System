using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour,IMove
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private bool isAllTimeUpdate = false;
	private bool canMove = false;
	public void Setup(Vector3 target,float distance)
    {
    }

	public void Run()
	{
		canMove = true;
		Look();
	}

	public void SetTargetTransform(Transform targetTransform)
	{
		this._targetTransform = targetTransform;
	}
	public void SetAngle(float angle)
	{
	}
	private void Update()
    {
        if (isAllTimeUpdate && canMove == true)
            Look();
    }

    private void Look()
    {
        if(_targetTransform != null)
        {
            Vector3 dir = _targetTransform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

	
}
