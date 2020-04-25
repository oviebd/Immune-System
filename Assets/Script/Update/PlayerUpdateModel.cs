using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpdateModel 
{
	public int currentUpdateWave = 0;
	public bool isItMaxUpdateWave = false;
	public int currentEnemyNumber = 0;
	public int requiredEnemyNumber = 5;
	public float remainingTimeInSec = 2.0f;
}
