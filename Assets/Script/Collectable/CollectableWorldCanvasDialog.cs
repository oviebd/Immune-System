using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableWorldCanvasDialog : PanelBase
{
    [SerializeField] private Text _messageTxt;


    public void SetCollectableMessageBasedOnCollectableType(GameEnum.CollectableType type)
    {
        _messageTxt.text = GetMessageText(type);
    }

    public string GetMessageText(GameEnum.CollectableType type)
    {
        string message = "";

        switch (type)
        {
            case GameEnum.CollectableType.Life:
                message = "Collect It for Increase Health";
                break;
            case GameEnum.CollectableType.Schild:
                message = "Collect It for Get Schild";
                break;
            case GameEnum.CollectableType.Update_Bullet:
                message = "Collect It for Update Weapon";
                break;
            case GameEnum.CollectableType.Update_Bullet_Frequency:
                message = "Collect It for Increase Bullet Frequence";
                break;
        }
        return message;
    }


}
