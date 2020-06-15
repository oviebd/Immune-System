using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBase : PanelBase
{
    [SerializeField] private Text _txtTitle;
    [SerializeField] private Text _txtMessage;
    [SerializeField] private GameEnum.DialogType _dialogType;

    private Delegate _delegate;

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

    public GameEnum.DialogType GetDialogType()
    {
        return _dialogType;
    }

    public void SetDialogDelegate(Delegate dialogDelegate)
    {
        this._delegate = dialogDelegate;
    }
    protected Delegate getDelegate()
    {
        return this._delegate;
    }

    public interface Delegate
    {
        void OnDialogPositiveButtonPressed();
    }
}
