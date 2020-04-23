using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	[SerializeField] private FloatingJoystick _rightJoystickForPlayerRotation;
	[SerializeField] private FloatingJoystick _leftJoystickForPlayerReposition;
	[SerializeField] private Camera _mainCamera;

	public static InputManager instance;

	private Vector2 rotationMovement;
	private Vector2 movement;

	private void Awake()
    {
		if (instance == null)
			instance = this;

		GameManager.onGameStateChange += OnGameStateChange;
    }

    private void OnDestroy()
    {
		GameManager.onGameStateChange -= OnGameStateChange;
	}

    public Vector2 GetPlayerRotationVector2()
    {
		if (Utils.IsItMobilePlatform())
            rotationMovement = new Vector2(_rightJoystickForPlayerRotation.Horizontal, _rightJoystickForPlayerRotation.Vertical);
        else
            rotationMovement = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
		return rotationMovement;
    }

	public Vector2 GetPlayerMovementVector2()
	{
		if (Utils.IsItMobilePlatform())
				movement = new Vector2(_leftJoystickForPlayerReposition.Horizontal, _leftJoystickForPlayerReposition.Vertical);
			else
				movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		return movement;
	}

    private void ResetInputData()
    {
		rotationMovement = Vector2.zero;
		movement = Vector2.zero;
	}

    private void OnGameStateChange(GameEnum.GameState gameState)
    {
		ResetInputData();
	}
}
