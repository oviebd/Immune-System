using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnum 
{
	public enum EnemyType { Type_1, Type_2,Type_3,Type_4,Type_5 }
	public enum PlayerShipType { PlayerType_1, PlayerType_2 , PlayerType_3, PlayerType_4, PlayerType_5 }
	public enum CollectableType { Schild, Life,Update_Bullet_Frequency,Update_Bullet }
	public enum GunType { GunType_1, GunType_2 }
	public enum UpgradeType { AddGun, RemoveGun }
    public enum GameTags { PlayerBullet, EnemyBullet, Player,Enemy}
	public enum GameState { Idle, Running, PauseGame, PlayerLose,PlayerWin, LevelChoose, StoreUiState,TutorialState }
	public enum UiState { StartGameState, PauseGameState, GameRunningState,GameOverState }
	public enum DialogType { AlertDialog,ActionDialog,InfoDialog,ImageDialog,Tutorial }
}
