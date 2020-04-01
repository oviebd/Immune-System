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

	public static float GetAngle(Vector3 target, Transform otherObj)
	{
		Vector2 playerRight = Vector2.zero;
		float towardsOther = (otherObj.position.y - playerRight.y) / (otherObj.position.x - playerRight.x);
		float angle = Mathf.Atan(towardsOther) * Mathf.Rad2Deg;
        angle = Mathf.Abs(angle);
		int quard = GetQuardLocation(otherObj.position) -1;

        if (quard == 3)
			angle = 360 - angle;
		else if (quard == 1)
			angle = 180 - angle;
		else
			angle = (quard * 90) + angle;

        return angle;
	}

	public static bool IsExceedMinimumDistance(Vector2 obj1,Vector2 obj2 , float targetedDistance)
	{
		float dist = Vector3.Distance(obj1, obj2);
		if (dist > targetedDistance)
			return false;
		else return true;
	}

    private static int GetQuardLocation(Vector3 point)
    {
		int quardNumber = 1;
		if (point.x > 0 && point.y > 0)
			quardNumber = 1;
        else if (point.x > 0 && point.y < 0 )
			quardNumber = 4;
		else if (point.x < 0 && point.y > 0)
			quardNumber = 2;
		else if (point.x < 0 && point.y < 0)
			quardNumber = 3;

		return quardNumber;
	}
}
