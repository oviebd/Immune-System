using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePanel : PanelBase
{
    [SerializeField] private StoreListItemHandler storeListItemHandler;

    public void Setup()
    {
        storeListItemHandler.Setup();
    }
}
