using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnum 
{
	public enum EnemyType { Type_1, Type_2 }
	public enum PlayerShipType { PlayerType_1, PlayerType_2 }
	public enum GunType { GunType_1, GunType_2 }
	public enum UpgradeType { AddGun, RemoveGun }
    public enum GameTags { PlayerBullet, EnemyBullet, Player,Enemy}
	public enum GameState { Idle, Running, PauseGame, PlayerLose,PlayerWin, LevelChoose, StoreUiState }
	public enum UiState { StartGameState, PauseGameState, GameRunningState,GameOverState }

}
