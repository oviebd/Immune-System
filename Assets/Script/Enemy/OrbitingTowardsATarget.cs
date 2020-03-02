using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingTowardsATarget : MonoBehaviour,IMove
{
    [SerializeField] private Transform _target;
	[SerializeField] private float angularSpeed = 1.0f;
	[SerializeField] private float _radious = 4.0f;

	private float _posX, _posY, _angle = 0.0f;
	private bool _isStopAndStoot = false;
	private float _stopTime = 2.0f;

	private void Start()
	{
		StartCoroutine(timeCounter());
	}

	public void Setup(Transform target,float distance)
    {
        this._target = target;
		this._radious = distance;
		_angle = MathHandler.GetAngle(_target, transform);
	}

	private void Update()
	{
		if (_isStopAndStoot)
        {
			MovementStop();
			return;
		}
			
		else
			RotateAround();
	}

	void RotateAround()
	{
		if (_target == null)
			return;
	
		if (MathHandler.IsExceedMinimumDistance(_target, transform, _radious) == false)
		{
			_posX = _target.position.x + Mathf.Cos(_angle) * _radious;
			_posY = _target.position.y + Mathf.Sin(_angle) * _radious;

			transform.position = new Vector2(_posX, _posY);
			_angle = _angle + Time.deltaTime * angularSpeed;
			Debug.Log("Calc angle ; " + _angle);
			if (_angle >= 360)
				_angle = 0;
		}

		
	}

	IEnumerator timeCounter()
	{
		yield return new WaitForSeconds(_stopTime);
		_isStopAndStoot = !_isStopAndStoot;

		StartCoroutine(timeCounter());
	}

    void MovementStop()
    {
		IENemyBehaviour behaviour = this.gameObject.GetComponent<IENemyBehaviour>();

		if (behaviour != null)
			behaviour.OnMovementStop();
	}
}
