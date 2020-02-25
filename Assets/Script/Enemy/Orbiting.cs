using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiting : MonoBehaviour
{
	public Transform center;
	public float radious = 2.0f;
	float angularSpeed = 2.0f;
	float posX, posY, angle = 0.0f;

	private void Update()
	{
		posX = center.position.x + Mathf.Cos(angle) * radious;
		posY = center.position.y + Mathf.Sin(angle) * radious;

		transform.position = new Vector2(posX,posY);
		angle = angle + Time.deltaTime * angularSpeed;

		if (angle >= 360)
			angle = 0;
	}
}
