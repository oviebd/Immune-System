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

	public static float GetAngle(Transform target, Transform otherObj)
	{
		Vector2 playerRight = target.right;
		Vector2 towardsOther = otherObj.position - target.position;

		//float angle = Vector2.Angle(playerRight, towardsOther);

		Vector3 dir = target.position - otherObj.position ;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		Debug.Log("Angle is :  " + angle);
		return angle;
	}

	public static bool IsExceedMinimumDistance(Transform obj1,Transform obj2 , float targetedDistance)
	{
		float dist = Vector3.Distance(obj1.position, obj2.position);
		//Debug.Log("Distance to other: " + dist);
		if (dist > targetedDistance)
			return true;
		else return false;
	}
}
