using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private GameEnum.GameState _currentGameState;
	public delegate void GameStateChange(GameEnum.GameState gameState);
	public static event GameStateChange onGameStateChange;

	public void SetGameState(GameEnum.GameState gameState)
	{
		_currentGameState = gameState;
		if (onGameStateChange != null)
			onGameStateChange(_currentGameState);
	}
	public GameEnum.GameState GetCurrentGameState()
	{
		return _currentGameState;
	}
	
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}
	void Start()
    {
		GameActionHandler.instance.GameInitialAction();

	}
	


}
