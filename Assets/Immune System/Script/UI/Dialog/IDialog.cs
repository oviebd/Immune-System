using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialog
{
    void SetTitle(string title);
    void SetMessage(string message);
    void SetDialogDelegate(DialogBase.Delegate dialogDelegate);
}
    

