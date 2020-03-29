using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed = 5.0f;

    private Vector2 _rotationMovement,_positionMovement;
	private bool _canRotate = false;
	bool flipRot = true;

	public FixedJoystick _rotationJoystick;
	public FixedJoystick _positionJoystick;

	private void Start()
	{
		TouchPointerHandler.onDragStarted    += onBeginDrag;
		TouchPointerHandler.onDragCompleted += onEndDrag;
	}
	private void OnDestroy()
	{
		TouchPointerHandler.onDragStarted    -= onBeginDrag;
		TouchPointerHandler.onDragCompleted -= onEndDrag;
	}
	void Update()
    {
		_rotationMovement = new Vector2(_rotationJoystick.Horizontal, _rotationJoystick.Vertical);
		_positionMovement = new Vector2(_positionJoystick.Horizontal, _positionJoystick.Vertical);
		//_positionMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		//_rotationMovement = _cam.ScreenToWorldPoint(Input.mousePosition);
	}
	

	private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _positionMovement * _moveSpeed * Time.fixedDeltaTime);

		if(_canRotate == true)
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
