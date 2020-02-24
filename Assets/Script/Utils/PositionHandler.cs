using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHandler : MonoBehaviour
{
	public static PositionHandler instance;

	public Transform topWall;
	public Transform bottomWall;
	public Transform rightWall;
	public Transform leftWall;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start()
    {
        
    }

	public Vector3 getRandomPosition()
	{
		float x = Random.Range(leftWall.position.x, rightWall.position.x);
		float y = Random.Range(bottomWall.position.y, topWall.position.y);
		Vector3 pos = new Vector3(x, y, 0);
		Debug.Log(pos);
		return pos;
	}
}
