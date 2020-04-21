using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogWithImage : DialogBase, IDialog
{

    [SerializeField] private CustomHorizontalViewPager _customHorizontalVP;

    public void SetImageList(List<Sprite> spriteList)
    {
        _customHorizontalVP.SetImageList(spriteList);
    }

    public void SetMessage(string message)
    {
        //SetDialogMessage(message);
    }

    public void SetTitle(string title)
    {
        SetDialogTitle(title);
    }

    public void OkButtonPressed()
    {
        HidePanelObj();
    }
}
