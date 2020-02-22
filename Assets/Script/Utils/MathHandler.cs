using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHandler 
{
	public static Vector3 CalculateRotration(Vector3 initialPosition, float angle, bool isClockwise) 
	{
		if (isClockwise)
		{
			angle = 2 * Mathf.PI - angle;
		}
		float xVal = initialPosition.x * Mathf.Cos(angle) - initialPosition.y * Mathf.Sin(angle);
		float yVal = initialPosition.x * Mathf.Sin(angle) + initialPosition.y * Mathf.Cos(angle);

		Vector3 resultedVector = new Vector3(xVal, yVal, initialPosition.z);
		return resultedVector;
	}
}
