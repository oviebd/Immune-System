using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingTowardsATarget : MonoBehaviour,IMove
{
    [SerializeField] private Transform _target;
	[SerializeField] private float angularSpeed = 0.5f;
	[SerializeField] private float _radious = 4.0f;

	private float _posX, _posY, _angle = 0.0f;
    
	private bool _isStopAndStoot = false;
	private float _stopTime = 2.0f;

	private bool isFirstTime = true;

	public bool CanMove = true;


	private void Start()
	{
		StartCoroutine(timeCounter());
	}

	public void Setup(Transform target,float distance)
    {
        this._target = target;
		this._radious = distance;
		//Rotating();
	}
    public void SetMoveAble(float an)
    {
		CanMove = true;
		_angle = an;

	}

	private void Update()
	{
        if(CanMove)
			RotateAround();

		/*if (_isStopAndStoot)
        {
			MovementStop();
			return;
		}
			
		else
			RotateAround();*/
	}

	void RotateAround()
	{
		if (_target == null)
			return;
		Rotating();
		/*if (MathHandler.IsExceedMinimumDistance(_target, transform, _radious) == false)
		{
			
		}*/
	}

    void Rotating()
    {
		/*if (isFirstTime == true)
		{
			_angle = MathHandler.GetAngle(_target, transform); // In Degree
			Debug.Log("Orbit Angle degree : " + _angle);
			_angle = _angle * Mathf.Deg2Rad; //Convert into Radians Because Sin Cos take radiant value
			Debug.Log("Orbit Angle rad : " + _angle);
			isFirstTime = false;
		}*/

		_posX = Mathf.Cos(_angle) * _radious;
		_posY = Mathf.Sin(_angle) * _radious;

		transform.position = new Vector2(_posX, _posY);
		_angle = _angle + Time.deltaTime * angularSpeed;

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
