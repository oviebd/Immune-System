using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private int _currentLevel = 1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        ScoreManager.onPlayerWin += OnlevelCompleted;
    }

    void Start()
    {
       // LoadALevel(_currentLevel);
    }

    public void LoadALevel(int levelNumber)
    {
        GameEnvironmentController.instance.LoadLevelEnvironment(levelNumber);
        ScoreManager.instance.SetWInningPoint(LevelDataHandler.instance.GetWinningPointOfALevel(levelNumber));
		GameUiVisibilityHandler.instance.ResetSliderData();

        //PlayerAchivedDataHandler.instance.AddPlayerShipTypeInAchievedList(GameEnum.PlayerShipType.PlayerType_1);
       //PlayerAchivedDataHandler.instance.GetAchievedPlayerShipList();
    }


    void OnlevelCompleted()
    {
		GameActionHandler.instance.ActionGameOver(true);
       // _currentLevel = _currentLevel + 1;
    }

    public int GetCurrentLevelNumber()
    {
        return _currentLevel;
    }
    public void SetCurrentLevelNumber(int levelNumber)
    {
        _currentLevel = levelNumber;
    }

    public bool IsPlayerCapableForGoNextLevel(int nextLevelNumber)
    {
        bool canPass = false;
        LevelRequiredDataModel levelRequiredData = LevelDataCreator.
                            GetLevelRequiredDataModel(nextLevelNumber);

        if (PlayerAchivedDataHandler.instance.IsGunTypeExistInAchievedGunList(levelRequiredData.gunType) == true &&
            PlayerAchivedDataHandler.instance.IsShipTypeExistInAchievedShipList(levelRequiredData.shipType) == true)
        {
            canPass = true;
        }
        return canPass;
    }
}
