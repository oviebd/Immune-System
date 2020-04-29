using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour,DialogBase.Delegate
{
    public static TutorialManager instance;

    //[SerializeField] private GameObject _instructionItemPrefab;
    [SerializeField] private Sprite _highlightedImage;
    [SerializeField] private List<GameObject> _positionList;
    [SerializeField] private List<string> _messageList;

    private IHighLighter _currentHighlighter;

    private List<InstructionDataModel> _instructionList = new List<InstructionDataModel>();

    int _currentInstructionIndex = 0;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ShowTutorial()
    {
        InsertInstructionInList();
    }

    private void InsertInstructionInList()
    {
        _instructionList.Clear();
        _currentInstructionIndex = 0;
        for (int i= 0; i<_positionList.Count && i<_messageList.Count; i++)
        {
            InstructionDataModel instructionModel = new InstructionDataModel();
            instructionModel.message = _messageList[i];
            instructionModel.instantiateParentObj = _positionList[i];
            _instructionList.Add(instructionModel);
        }

        ShowInstructions();
    }

    private void ShowInstructions()
    {
        if (_instructionList != null && _currentInstructionIndex <_instructionList.Count)
        {
            InstructionDataModel data = _instructionList[_currentInstructionIndex];
            IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.Tutorial);
            _currentHighlighter = data.instantiateParentObj.GetComponent<IHighLighter>();

            if (_currentHighlighter != null)
            {
                _currentHighlighter.SetHighlightProperties(_highlightedImage, Color.red);
                _currentHighlighter.ShowHighlight();
            }
               
            if (dialog != null)
            {
                dialog.SetMessage(data.message);
                dialog.SetDialogDelegate(this);
            }
        }
       
    }

    public void OnDialogPositiveButtonPressed()
    {
        if (_currentHighlighter != null)
            _currentHighlighter.HideHighlight();
       
        _currentInstructionIndex = _currentInstructionIndex + 1;

        if (_instructionList != null && _currentInstructionIndex < _instructionList.Count)
            ShowInstructions();
        else
        {
            GameActionHandler.instance.BackButtonPressed();
            GameEnvironmentController.instance.SetEnvironmentForTutorialComplete();
            GameDataHandler.instance.SetTutorialStatusShown();
        }

    }
}
