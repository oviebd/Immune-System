using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDialogBase : DialogBase,IDialog
{
    public void SetMessage(string message)
    {
        SetDialogMessage(message);
    }

    public void SetTitle(string title)
    {
        SetDialogTitle(title);
    }

    public void OkButtonPressed()
    {
        if (getDelegate() != null)
            getDelegate().OnDialogPositiveButtonPressed();
        HidePanelObj();
    }
}
