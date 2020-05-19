using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUiPanel : PanelBase
{
    [SerializeField] private Image _soundButton;
    [SerializeField] private Sprite _spriteSoundOn;
    [SerializeField] private Sprite _spriteSoundOff;

	[SerializeField] private Text _totalScoreText;
	[SerializeField] private Image _currentPlayerImage;
	[SerializeField] private GameObject _currentPlayerImagePanelObj;
	private void Start()
    {

        AudioManager.onAudioStateChange += AudioStateChanged;
		GameManager.onGameStateChange += OnGameStateChanged;
		GameDataHandler.onCurrentPlayerChange += OnPlayerChange;

		SetSoundButtonGraphics();
		SetCurrentPlayerGraphics();
		
    }
    private void OnDestroy()
    {
        AudioManager.onAudioStateChange -= AudioStateChanged;
		GameManager.onGameStateChange -= OnGameStateChanged;
		GameDataHandler.onCurrentPlayerChange -= OnPlayerChange;
	}

	private void Update()
	{
		_totalScoreText.text = PlayerAchivedDataHandler.instance.GetTotalScore() + "";
	}
	public void SoundButtonClicked()
    {
        AudioManager.instance.ChangeGameAudioStatus();
        SetSoundButtonGraphics();
    }

    private void SetSoundButtonGraphics()
    {
        bool isAudioOn = AudioManager.instance.IsGameAudioOn();
        if (isAudioOn)
            _soundButton.sprite = _spriteSoundOn;
        else
            _soundButton.sprite = _spriteSoundOff;
    }

    private void AudioStateChanged()
    {
        SetSoundButtonGraphics();
    }

	private void ShowHideObjs(bool canShow)
	{
		_currentPlayerImagePanelObj.SetActive(canShow);
		_totalScoreText.gameObject.SetActive(canShow);
	}

	private void SetCurrentPlayerGraphics()
	{
		GameObject playerObj = PlayerSpawnerController.instance.GetSpecificPlayerBasedOnType(GameDataHandler.instance.GetCurrentPlayer());
		if(playerObj != null)
		{
			PlayerController playerController = playerObj.GetComponent<PlayerController>();
			Sprite playerSprite = playerController.GetPlayerSprite();

			if (playerSprite != null)
				_currentPlayerImage.sprite = playerSprite;
		}
	}

	void OnPlayerChange(GameEnum.PlayerType playerType)
	{
		SetCurrentPlayerGraphics();
	}
	void OnGameStateChanged(GameEnum.GameState state)
	{
		if( state == GameEnum.GameState.Idle || state == GameEnum.GameState.StoreUiState)
			ShowHideObjs(true);
		else
			ShowHideObjs(false);
	}

}
