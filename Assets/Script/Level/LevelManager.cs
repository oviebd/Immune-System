using UnityEngine;

public class LevelManager : MonoBehaviour, DialogBase.Delegate
{
    public static LevelManager instance;
    [SerializeField] private LevelDataScriptable _levelDataScriptable;
    private LevelRequiredDataModel _levelRequiredData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        ScoreManager.onPlayerWin += OnlevelCompleted;
    }

    public void LoadALevel(int levelNumber)
    {
        SetCurrentLevelNumber(levelNumber);
        GameEnvironmentController.instance.LoadLevelEnvironment(levelNumber);
        ScoreManager.instance.SetWInningPoint(LevelDataHandler.instance.GetWinningPointOfALevel(levelNumber));
        GameUiVisibilityHandler.instance.ResetSliderData();
        /*if(IsPlayerCapableForGoNextLevel(levelNumber) == true)
        {
            SetCurrentLevelNumber(levelNumber);
            GameEnvironmentController.instance.LoadLevelEnvironment(levelNumber);
            ScoreManager.instance.SetWInningPoint(LevelDataHandler.instance.GetWinningPointOfALevel(levelNumber));
            GameUiVisibilityHandler.instance.ResetSliderData();
        }
        else
        {
            SetStoreUiDialog(levelNumber);
            GameStateTracker.instance.PopGameState();
        }*/
    }

    void SetStoreUiDialog(int levelNumber)
    {
        if (GetlevelRequiredData(levelNumber) == null)
            return;

        IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
        dialog.SetMessage("");
        dialog.SetTitle("You Need " + GetlevelRequiredData(levelNumber).shipType + " Please Open Store For Puchasing Items ");
        dialog.SetDialogDelegate(this);
    }

    void OnlevelCompleted()
    {
		GameActionHandler.instance.ActionGameOver(true);
        PlayerAchivedDataHandler.instance.SetMaxCompletedLevelNumber(GetCurrentLevelNumber()+1);
    }

    public int GetCurrentLevelNumber()
    {
        if (_levelDataScriptable == null)
            return 1;
        else
            return _levelDataScriptable.currentLevel;
    }

    private void SetCurrentLevelNumber(int levelNumber)
    {
        if (_levelDataScriptable == null)
            return;
        _levelDataScriptable.currentLevel = levelNumber;
    }

    public bool IsPlayerCapableForGoNextLevel(int nextLevelNumber)
    {
        if (GetlevelRequiredData(nextLevelNumber) == null) 
            return true;
        return PlayerAchivedDataHandler.instance.IsShipTypeExistInAchievedShipList(GetlevelRequiredData(nextLevelNumber).shipType);
     
        /* LevelRequiredDataModel levelRequiredData = LevelDataCreator.
                             GetLevelRequiredDataModel(nextLevelNumber);
       if (PlayerAchivedDataHandler.instance.IsGunTypeExistInAchievedGunList(levelRequiredData.gunType) == true)
             && PlayerAchivedDataHandler.instance.IsShipTypeExistInAchievedShipList(levelRequiredData.shipType) == true)
         {
             canPass = true;
         }*/
    }

    private LevelRequiredDataModel GetlevelRequiredData(int levelNumber)
    {
        if(_levelRequiredData == null)
            _levelRequiredData = LevelDataCreator.GetLevelRequiredDataModel(levelNumber);
        return _levelRequiredData;
    }

    public void OnDialogPositiveButtonPressed()
    {
        GameActionHandler.instance.ActionShowStore();
    }

}
