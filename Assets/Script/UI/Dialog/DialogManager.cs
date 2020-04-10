using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Showdialog(IDialog dialog)
    {

    }
}
