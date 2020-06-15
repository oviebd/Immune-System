using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add This script to any object, which has some poin value. 
public class Reward_Point : MonoBehaviour,IReward
{
    [Header("Value of this Object. Destroyer will get achieve this amount of point  ")]
    [SerializeField] private int _point = 1;

    public int GetReward()
    {
        return _point;
    }

    public void SetReward(int rewordPoint)
    {
        _point = rewordPoint;
    }
}
