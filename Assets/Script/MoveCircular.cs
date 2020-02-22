using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircular : MonoBehaviour
{
	float rotationSpeed = 10.0f;
	bool isButtonPressed = false;
    void Start()
    {
	
	}

 
    void Update()
    {
		float rotation = 0 ;

		if (Input.GetKey(KeyCode.A) || isButtonPressed) 
		{
			rotation = 1;
			rotation *= Time.deltaTime * rotationSpeed;
			transform.up = RotateFunction(transform.up, rotation, true);
		}

	}

	public void ButtonPressedDown()
	{
		isButtonPressed = true;
	}

	Vector3 RotateFunction(Vector3 initialPosition, float angle, bool isClockwise)
	{
		if (isClockwise)
		{
			angle = 2 * Mathf.PI - angle;
		}
		float xVal = initialPosition.x * Mathf.Cos(angle) - initialPosition.y * Mathf.Sin(angle);
		float yVal = initialPosition.x * Mathf.Sin(angle) + initialPosition.y * Mathf.Cos(angle);

		Vector3 resultedVector = new Vector3(xVal, yVal, initialPosition.z);
		//Debug.Log(resultedVector);
		return resultedVector;
	}
}
