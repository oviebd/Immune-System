using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward_Point : MonoBehaviour,IReward
{
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
