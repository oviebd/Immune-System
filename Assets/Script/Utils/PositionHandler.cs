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
	public Vector3 InstantiateEnemyInRandomPosition()
	{
		float xPos = 0, yPos = 0;
		float threshHold = 4;

		float randomYPos = Random.Range(BoundaryController.instance.GetTopWallPosition().y, BoundaryController.instance.GetBottomWallPosition().y);
		float randomXPos = Random.Range(BoundaryController.instance.GetRightWallPosition().x, BoundaryController.instance.GetLeftWallPosition().x);

		int range = Random.Range(0, 4);

		switch (range)
		{
			case 0:
				// Right Pos 
				xPos = BoundaryController.instance.GetRightWallPosition().x + threshHold;
				yPos = randomYPos;
				break;
			case 1:
				//Left Pos
				xPos = BoundaryController.instance.GetLeftWallPosition().x - threshHold;
				yPos = randomYPos;
				break;
			case 2:
				//Top Pos
				xPos = randomXPos;
				yPos = BoundaryController.instance.GetTopWallPosition().y + threshHold;
				break;
			case 3:
				//Top Pos
				xPos = randomXPos;
				yPos = BoundaryController.instance.GetBottomWallPosition().y - threshHold;
				break;
		}

		Vector3 pos = new Vector3(xPos, yPos, 0);
		return pos;
	}

	public Vector3 InstantiateCollectableInARandomPosition()
	{
		float threshHoldX =1;
		float threshHoldY = 2.5f;

		float randomYPos = Random.Range(BoundaryController.instance.GetTopWallPosition().y - threshHoldY, BoundaryController.instance.GetBottomWallPosition().y + threshHoldY);
		float randomXPos = Random.Range(BoundaryController.instance.GetRightWallPosition().x - threshHoldX, BoundaryController.instance.GetLeftWallPosition().x + threshHoldX);

		Vector3 pos = new Vector3(randomXPos, randomYPos, 0);
		
		return pos;
		
		/*int range = Random.Range(0, 4);
		switch (range)
		{
			case 0:
				// Right Pos 
				xPos = BoundaryController.instance.GetRightWallPosition().x + threshHold;
				yPos = randomYPos;
				break;
			case 1:
				//Left Pos
				xPos = BoundaryController.instance.GetLeftWallPosition().x - threshHold;
				yPos = randomYPos;
				break;
			case 2:
				//Top Pos
				xPos = randomXPos;
				yPos = BoundaryController.instance.GetTopWallPosition().y + threshHold;
				break;
			case 3:
				//Top Pos
				xPos = randomXPos;
				yPos = BoundaryController.instance.GetBottomWallPosition().y - threshHold;
				break;
		}

		Vector3 pos = new Vector3(xPos, yPos, 0);
		Debug.Log("Random Pos : " + pos);
		return pos;*/
	}

}
