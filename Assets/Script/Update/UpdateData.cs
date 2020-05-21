using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateData : MonoBehaviour
{
    public float requiredTime = 10.0f;
    public int requiredEnemy = 12; //Base number of enemy need to destroy in a given time.
    public float updateFactor = 6;  // Used for set Difficulty .Responsible for calculated enemy number based on waveNumber


    private void Start()
    {
        PlayerUpdateController.instance.SetUpdateData(requiredTime, requiredEnemy, updateFactor);
    }

}
