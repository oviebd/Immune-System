
/*
 * If platform is mobilenplatform then we consider input from joystick. This will handle by InputManager
 * for rotation we need to consider when joystick drag started and end.
 * when rotation joystick start drag then player can rotate and when it end its draging then player lost its rotation capabilities
 * If we do not consider those drag , then after drag end player will rotate 0 degree instead its previous value
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed = 5.0f;

    private Vector2 _rotationMovement,_positionMovement;
	private bool _canRotate = false;
	private bool flipRot = true;

	private void Start()
	{
		if (Utils.IsItMobilePlatform() == true)
            // If platform is mac or Pc then player will rotate based on Mouse position. In this case we do not need to consider joystick drag
        {
			TouchPointerHandler.onDragStarted += onBeginDrag;
			TouchPointerHandler.onDragCompleted += onEndDrag;
		}
	}
	private void OnDestroy()
	{
		if (Utils.IsItMobilePlatform() == true)
		{
			TouchPointerHandler.onDragStarted -= onBeginDrag;
			TouchPointerHandler.onDragCompleted -= onEndDrag;
		}
	}
	void Update()
    {
		_rotationMovement = InputManager.instance.GetPlayerRotationVector2();
		_positionMovement = InputManager.instance.GetPlayerMovementVector2();
	}
	

	private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _positionMovement * _moveSpeed * Time.fixedDeltaTime);

		if(_canRotate == true || Utils.IsItMobilePlatform() == false)
		{
			float angle = (Mathf.Atan2(_rotationMovement.x, _rotationMovement.y) * Mathf.Rad2Deg);
			angle = flipRot ? -angle : angle;
			_rb.MoveRotation(angle);
		}
		/*Vector2 lookDir = mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;*/
    }

	void onBeginDrag()
	{
		_canRotate = true;
	}
	void onEndDrag()
	{
		_canRotate = false;
	}
}
