using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiting : MonoBehaviour
{
	public Transform center;
	public float radious = 2.0f;
	float angularSpeed = 2.0f;
	float posX, posY, angle = 0.0f;

	bool isStopAndStoot = true;

    private void Start()
    {
		StartCoroutine(timeCounter());
	}

    private void Update()
	{
		if (isStopAndStoot)
			return;
		else
			RotateAround();

       
	}

    void RotateAround()
    {
		posX = center.position.x + Mathf.Cos(angle) * radious;
		posY = center.position.y + Mathf.Sin(angle) * radious;

		transform.position = new Vector2(posX, posY);
		angle = angle + Time.deltaTime * angularSpeed;

		if (angle >= 360)
			angle = 0;
	}

    IEnumerator timeCounter()
    {
		yield return new WaitForSeconds(1.0f);
		isStopAndStoot = !isStopAndStoot;

		StartCoroutine(timeCounter());
    }
}
