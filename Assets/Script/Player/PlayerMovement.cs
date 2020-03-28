using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed = 5.0f;

    private Vector2 _movement,mousePos;

    public FixedJoystick joyStick;
   
    void Update()
    {
        // _movement.x = Input.GetAxisRaw("Horizontal");
        // _movement.y = Input.GetAxisRaw("Vertical");
        _movement.x = joyStick.Horizontal;
        _movement.y = joyStick.Vertical;

        Debug.Log(Input.touchCount);
        if (Input.touchCount > 0)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            Debug.Log(touchPos);
        }

        mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
       
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;
    }
}
