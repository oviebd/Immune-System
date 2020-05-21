using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnvironmentLevelDataScriptable : ScriptableObject
{
	public int levelNumber = 1;
	public AudioClip audioClip;
	public GameObject backgroundImage;

	[Header("Update Setting")]
	public float requiredTime = 10.0f;
	public int requiredEnemy = 12; //Base number of enemy need to destroy in a given time.
	public float updateFactor = 6;  // Used for set Difficulty .Responsible for calculated enemy number based on waveNumber
}
