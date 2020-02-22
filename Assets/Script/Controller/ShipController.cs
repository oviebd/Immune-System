using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
	private bool _canRotate = false;
	[SerializeField] private float _rotationSpeed = 10;

    void Start()
    {
		InputManager.onRotationInputButtonPressed += SetRotation;
    }

	private void OnDestroy()
	{
		InputManager.onRotationInputButtonPressed -= SetRotation;
	}

	void Update()
    {
		float rotation = 0;
		if (_canRotate)
		{
			rotation = 1;
			rotation *= Time.deltaTime * _rotationSpeed;
			transform.up = MathHandler.CalculateRotration (transform.up, rotation, true);
		}
    }

	void SetRotation(bool canMove)
	{
		_canRotate = canMove;
	}
}
