using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingTowardsATarget : MonoBehaviour,IMove
{
    [SerializeField] private Transform target;
	[SerializeField] private float angularSpeed = 1.0f;
	[SerializeField] private float radious = 4.0f;

	private float _posX, _posY, _angle = 0.0f;
	private bool _isStopAndStoot = false;
	private float _stopTime = 2.0f;

	private void Start()
	{
		StartCoroutine(timeCounter());
	}

	public void Setup(Transform target)
    {
        this.target = target;
    }

	private void Update()
	{
		if (_isStopAndStoot)
        {
			Shoot();
			return;
		}
			
		else
			RotateAround();
	}

	void RotateAround()
	{
		if (target == null)
			return;

		_posX = target.position.x + Mathf.Cos(_angle) * radious;
		_posY = target.position.y + Mathf.Sin(_angle) * radious;

		transform.position = new Vector2(_posX, _posY);
		_angle = _angle + Time.deltaTime * angularSpeed;

		if (_angle >= 360)
			_angle = 0;
	}

	IEnumerator timeCounter()
	{
		yield return new WaitForSeconds(_stopTime);
		_isStopAndStoot = !_isStopAndStoot;

		StartCoroutine(timeCounter());
	}

    void Shoot()
    {
		GunController gunController = this.gameObject.GetComponent<GunController>();
        if(gunController != null)
        {
			gunController.Shoot();

		}
    }
}
