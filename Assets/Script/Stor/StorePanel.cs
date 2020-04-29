using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePanel : PanelBase
{
    public static StorePanel instance;
    [SerializeField] private StoreListItemHandler storeListItemHandler;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Setup()
    {
        storeListItemHandler.Setup();
    }

    public void ShowItemInfo(StoreItemModel data)
    {
        IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.InfoDialog);
        dialog.SetTitle(data.itemType.ToString());
        dialog.SetMessage(GetStoreItemDetailsBasedOnType(data.itemType));
    }

    public void BuyButtonClicked(StoreItemModel data)
    {
    }



    private string GetStoreItemDetailsBasedOnType(GameEnum.PlayerrTType type)
    {
        string details = "";
        switch (type)
        {
            case  GameEnum.PlayerrTType.PlayerType_1:
                details = "Initial Player .. Initially it has one gun and each 0.5 s it will shoot";
                break;
            case GameEnum.PlayerrTType.PlayerType_2:
                details = "Second Player .. Initially it has one gun and each 0.4 s it will shoot";
                break;
            case GameEnum.PlayerrTType.PlayerType_3:
                details = "Third Player .. Initially it has one gun and each 0.3 s it will shoot";
                break;
            case GameEnum.PlayerrTType.PlayerType_4:
                details = "Fourth Player .. Initially it has one gun and each 0.2 s it will shoot";
                break;
            case GameEnum.PlayerrTType.PlayerType_5:
                details = "Fifth Player .. Initially it has one gun and each 0.1 s it will shoot";
                break;

        }
        return details;

    }
}
