using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour,IMove
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private bool isAllTimeUpdate = false;
	private bool _canMove = false;

    public void Setup(GameObject target,float distance)
    {
    }

	public void Run()
	{
		_canMove = true;
		Look();
	}

	public void SetTargetObject(GameObject targetObject)
	{
		this._targetTransform = targetObject.transform;
	}
	public void SetAngle(float angle)
	{
	}
	private void Update()
    {
        if (isAllTimeUpdate && _canMove == true)
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

    public void StopMovement()
    {
        _canMove = false;
    }
}
