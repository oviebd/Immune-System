using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StoreItemScriptable : ScriptableObject
{
    public string itemName;
    public GameEnum.GunType itemType;
    public Sprite itemImage;
    public bool isPurchased = false;
    public int price = 0;
    public int playerId = 0;
}
