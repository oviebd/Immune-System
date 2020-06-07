
/*
 * If platform is mobilenplatform then we consider input from joystick. This will handle by InputManager
 * for rotation we need to consider when joystick drag started and end.
 * when rotation joystick start drag then player can rotate and when it end its draging then player lost its rotation capabilities
 * If we do not consider those drag , then after drag end player will rotate 0 degree instead its previous value
 */
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
		MovePlayer();
		if(_canRotate == true || Utils.IsItMobilePlatform() == false)
		{
			float angle = (Mathf.Atan2(_rotationMovement.x, _rotationMovement.y) * Mathf.Rad2Deg);
			angle = flipRot ? -angle : angle;
			_rb.MoveRotation(angle);
		}
	}

    void MovePlayer()
    {
		float threshHold = 0.3f;
		Vector2 newPos = _rb.position + _positionMovement * _moveSpeed * Time.fixedDeltaTime;

		if (newPos.y > (BoundaryController.instance.GetTopWallPosition().y - threshHold))
			newPos.y = BoundaryController.instance.GetTopWallPosition().y - threshHold;
		if (newPos.y < (BoundaryController.instance.GetBottomWallPosition().y + threshHold))
			newPos.y = BoundaryController.instance.GetBottomWallPosition().y + threshHold;
		if (newPos.x > (BoundaryController.instance.GetRightWallPosition().x - threshHold))
			newPos.x = BoundaryController.instance.GetRightWallPosition().x - threshHold;
		if (newPos.x < (BoundaryController.instance.GetLeftWallPosition().x + threshHold))
			newPos.x = BoundaryController.instance.GetLeftWallPosition().x + threshHold;

		_rb.MovePosition(newPos);
	}

	void onBeginDrag()
	{
		_canRotate = true;
	}
	void onEndDrag()
	{
		_canRotate = false;
	}
    public float GetPlayerMoveSpeed()
    {
		return _moveSpeed;
    }

}
