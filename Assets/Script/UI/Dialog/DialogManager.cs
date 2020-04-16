using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour,DialogBase.Delegate
{
    public static DialogManager instance;

    [SerializeField] private GameObject _dialogParent;
    [SerializeField] private List<DialogBase> _dialogList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
      /*  IDialog dialog = SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
        dialog.SetMessage("Test Message");
        dialog.SetTitle("Set Title..");
        dialog.SetDialogDelegate(this);*/
        
    }

    public IDialog SpawnDialogBasedOnType(GameEnum.DialogType type)
    {
        IDialog iDialog = null;
        GameObject dialogObj = GetSpecificDialogBasedOnType(type);
        if (dialogObj != null)
        {
            iDialog = InstantiateDialog(dialogObj);
        }
        return iDialog;
    }
    public IDialog SpawnDialogBasedOnGameObj(GameObject dialogObj)
    {
        IDialog iDialog = null;
        if (dialogObj != null)
        {
            iDialog = InstantiateDialog(dialogObj);
        }
        return iDialog;
    }

    IDialog InstantiateDialog(GameObject dialog)
    {
        GameObject newObj = Instantiate(dialog, _dialogParent.transform);
        newObj.transform.parent = _dialogParent.transform;
        IDialog iDialog = newObj.GetComponent<IDialog>();
        return iDialog;
    }

    private GameObject GetSpecificDialogBasedOnType(GameEnum.DialogType type)
    {
        for (int i = 0; i < _dialogList.Count; i++)
        {
            if (type == _dialogList[i].GetDialogType())
            {
                return _dialogList[i].gameObject;
            }
        }
        return null;
    }

    public void OnDialogPositiveButtonPressed()
    {
        Debug.Log("Interface Ok ");
    }
}
