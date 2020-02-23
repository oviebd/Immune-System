using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	private bool _isRotationInputButtonPressed = false;

	public delegate void RotationInputButtonPressed( bool isPressed);
	public static event RotationInputButtonPressed onRotationInputButtonPressed;

	public delegate void ShootInputButtonPressed();
	public static event ShootInputButtonPressed onShootButtonPressed;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
			RotationButtonPressedDown();

		if (Input.GetKeyUp(KeyCode.A))
			RotationButtonPressedUp();

		if (Input.GetKey(KeyCode.S))
			ShootButtonPressed();

		onRotationInputButtonPressed(_isRotationInputButtonPressed);
	}

	public void RotationButtonPressedDown()
	{
		_isRotationInputButtonPressed = true;
	}
	public void RotationButtonPressedUp()
	{
		_isRotationInputButtonPressed = false;
	}

	public void ShootButtonPressed()
	{
		onShootButtonPressed();
	}
}
