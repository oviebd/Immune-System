using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectableLevelDataScriptable : ScriptableObject
{
    public int levelNumber = 1;
    public int noOfCollectableForCurrentLevel = 3;
    public float minumumTimeDelayPerCollectable = 10.0f;
    public List<GameEnum.CollectableType> collectableType;
    public List<int> collectablePercentageList;
}
