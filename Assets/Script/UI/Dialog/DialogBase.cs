using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBase : PanelBase
{
    [SerializeField] private Text _txtTitle;
    [SerializeField] private Text _txtMessage;

    public void SetDialogTitle(string title)
    {
        _txtTitle.text = title;
    }
    public void SetDialogMessage(string message)
    {
        _txtMessage.text = message;
    }

    public void OnCancelButtonPressed()
    {
        HidePanelObj();
    }
}
