using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDataModel 
{
    public int levelNumber = 1;
    public int noOfCollectableForCurrentLevel = 3;
    public float minumumTimeDelayPerCollectable = 10.0f;
    public Dictionary<GameEnum.CollectableType, int> collectableTypeAndPercentageDictionary = new Dictionary<GameEnum.CollectableType, int>();
}
