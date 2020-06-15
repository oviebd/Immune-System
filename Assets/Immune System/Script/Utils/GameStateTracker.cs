using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTracker : MonoBehaviour
{
	public static GameStateTracker instance;
	private Stack<GameEnum.GameState> _gameStateStack = new Stack<GameEnum.GameState>();


    private void Awake()
	{
		if (instance == null)
			instance = this;
	}

    public void PushGameState(GameEnum.GameState state)
    {
        if (_gameStateStack != null)
        {
            _gameStateStack.Push(state);
            GameManager.instance.SetGameState(state);
        }
    }
    public void PopGameState()
    {
        if (_gameStateStack != null && _gameStateStack.Count > 0)
        {
            _gameStateStack.Pop();

            if(_gameStateStack.Peek() != null)
            {
                GameManager.instance.SetGameState(_gameStateStack.Peek());
            }

        }  
    }

}
