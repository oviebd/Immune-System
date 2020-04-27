using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionDialog : DialogBase,IDialog
{

    public void OnOkButtonClicked()
    {
        if (getDelegate() != null)
            getDelegate().OnDialogPositiveButtonPressed();
        HidePanelObj();
    }

    public void SetMessage(string message)
    {
        SetDialogMessage(message);
    }

    public void SetTitle(string title)
    {
       
    }
}
