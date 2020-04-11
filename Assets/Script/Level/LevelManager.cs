using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private LevelDataScriptable _levelDataScriptable;

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
        bool canPass = false;
        LevelRequiredDataModel levelRequiredData = LevelDataCreator.
                            GetLevelRequiredDataModel(nextLevelNumber);

        if (PlayerAchivedDataHandler.instance.IsGunTypeExistInAchievedGunList(levelRequiredData.gunType) == true)
           // && PlayerAchivedDataHandler.instance.IsShipTypeExistInAchievedShipList(levelRequiredData.shipType) == true)
        {
            canPass = true;
        }
        return canPass;
    }
}
