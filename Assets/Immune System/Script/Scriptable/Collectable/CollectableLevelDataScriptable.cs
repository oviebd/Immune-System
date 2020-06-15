using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectableLevelDataScriptable : ScriptableObject
{
    [Header("Level number for this setting")]
    public int levelNumber = 1;
    [Header("How many collectable will show in this level")]
    public int noOfCollectableForCurrentLevel = 3;
    [Header("minimum time for spawning each collectable")]
    public float minumumTimeDelayPerCollectable = 10.0f;
    [Header("Collectable Type List for this Level. Do not input one type twice")]
    public List<GameEnum.CollectableType> collectableType;
    [Header("Percentage  of each collectable type. maintain collectableType list order. made percentage  sum exactly 100")]
    public List<int> collectablePercentageList;
}
