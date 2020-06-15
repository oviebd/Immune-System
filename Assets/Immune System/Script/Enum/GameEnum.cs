using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnum 
{
	public enum EnemyType { Type_1, Type_2,Type_3,Type_4,Type_5,Type_6,Type_7,Type_8,Type_9 }
	public enum PlayerType { Type_1_Base, Type_2_Dozzer , Type_3_Healthy, Type_4_Shooter }
	public enum CollectableType { Schild, Life,Update_Bullet_Frequency,Update_Bullet }
	public enum GunType { GunType_1, GunType_2 }
	public enum UpgradeType { AddGun, RemoveGun }
    public enum GameTags { PlayerBullet, EnemyBullet, Player,Enemy,Background}
	public enum GameState { Idle, Running, PauseGame, PlayerLose,PlayerWin, LevelChoose, StoreUiState,TutorialState }
	public enum UiState { StartGameState, PauseGameState, GameRunningState,GameOverState,TutorialUiState }
	public enum DialogType { ErrorDialog,ActionDialog,InfoDialog,ImageDialog,Tutorial }
}
