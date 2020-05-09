using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateData : MonoBehaviour
{
    [SerializeField] private float _requiredTime = 10.0f;
    [SerializeField] private int _requiredEnemy = 12; //Base number of enemy need to destroy in a given time.
    [SerializeField] private float _updateFactor = 6;  // Used for set Difficulty .Responsible for calculated enemy number based on waveNumber


    private void Start()
    {
        PlayerUpdateController.instance.SetUpdateData(_requiredTime, _requiredEnemy, _updateFactor);
    }

}
