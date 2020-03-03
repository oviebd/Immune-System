using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingTowardsATarget : MonoBehaviour,IMove
{
    [SerializeField] private Vector3 _target;
	[SerializeField] private float angularSpeed = 0.5f;
	[SerializeField] private float _radious = 4.0f;
	float counter = 0f;

	private float _posX, _posY, _angle = 0.0f;
    
	private bool _isStopAndStoot = false;
	private float _stopTime = 2.0f;

	private bool isFirstTime = true;

	public bool CanMove = true;


	private void Start()
	{
		StartCoroutine(timeCounter());
	}

	public void Setup(Vector3 target,float distance)
    {
        this._target = target;
		this._radious = distance;
		//Rotating();
	}

	public void Run()
	{

	}

	public void SetTargetTransform(Transform targetTransform)
	{
	}

	public void SetAngle(float angle)
	{
		this._angle = angle;
	}
	public void SetMoveAble()
    {
	       CanMove = true;
	}

	private void Update()
	{
		if (CanMove == true)
		{
			if (_isStopAndStoot)
			{
				MovementStop();
				counter = 0;
			}
			else
			{
				RotateAround();
			}
		}
	}

	void RotateAround()
	{
		if (_target == null)
			return;
		Rotating();
	}

    void Rotating()
    {
		Debug.Log("Rotating ... ");
		_posX = Mathf.Cos(_angle) * _radious;
		_posY = Mathf.Sin(_angle) * _radious;

		transform.position = new Vector2(_posX, _posY);
		counter = counter + .0001f;
		//_angle = _angle + counter * angularSpeed;
		_angle = _angle + counter * angularSpeed;
		if (_angle > 360)
			_angle = 0;
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
