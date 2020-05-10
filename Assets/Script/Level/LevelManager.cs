using UnityEngine;

public class LevelManager : MonoBehaviour, DialogBase.Delegate
{
    public static LevelManager instance;
    
   // private LevelRequiredDataModel _levelRequiredData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        ScoreManager.onPlayerWin += OnlevelCompleted;
    }

    public void LoadALevel(int levelNumber)
    {
        GameDataHandler.instance.SetCurrentLevelNumber(levelNumber);
        GameEnvironmentController.instance.LoadLevelEnvironment(levelNumber);
        GameUiVisibilityHandler.instance.ResetSliderData();

        if(TutorialManager.instance.IsTutorialShownAlready() == false)
        {
            Invoke("ShoTutorial", 2.0f);
        }
    }

    void ShoTutorial()
    {
        GameActionHandler.instance.ActionShowTutorial();
    }

    void SetStoreUiDialog(int levelNumber)
    {
        /*if (GetlevelRequiredData(levelNumber) == null)
            return;*/

        IDialog dialog = DialogManager.instance.SpawnDialogBasedOnType(GameEnum.DialogType.ActionDialog);
        dialog.SetMessage("");
        //dialog.SetTitle("You Need " + GetlevelRequiredData(levelNumber).shipType + " Please Open Store For Puchasing Items ");
        dialog.SetDialogDelegate(this);
    }

    void OnlevelCompleted()
    {
		GameActionHandler.instance.ActionGameOver(true);
        PlayerAchivedDataHandler.instance.SetMaxCompletedLevelNumber(GetCurrentLevelNumber()+1);
    }

    public int GetCurrentLevelNumber()
    {
        return GameDataHandler.instance.GetCurrentLevelNumber();
    }


   /* public bool IsPlayerCapableForGoNextLevel(int nextLevelNumber)
    {
        if (GetlevelRequiredData(nextLevelNumber) == null) 
            return true;
        return PlayerAchivedDataHandler.instance.IsShipTypeExistInAchievedShipList(GetlevelRequiredData(nextLevelNumber).shipType);
    
    }*/

   /* private LevelRequiredDataModel GetlevelRequiredData(int levelNumber)
    {
        if(_levelRequiredData == null)
            _levelRequiredData = LevelDataCreator.GetLevelRequiredDataModel(levelNumber);
        return _levelRequiredData;
    }*/

    public void OnDialogPositiveButtonPressed()
    {
        GameActionHandler.instance.ActionShowStore();
    }

}
