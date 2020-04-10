using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationNotificationDialog : DialogBase, IDialog
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

    }
}
