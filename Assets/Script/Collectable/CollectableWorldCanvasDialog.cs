using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableWorldCanvasDialog : PanelBase
{
    [SerializeField] private Text _messageTxt;


    public void SetMessage(string message)
    {
        _messageTxt.text = message;
    }


}
