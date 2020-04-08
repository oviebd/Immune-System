using UnityEngine;

[CreateAssetMenu]
public class PlayerLevelDataScriptable : ScriptableObject
{
    public int levelNumber = 1;
    public GameObject playerPrefab;
    public GameObject playerGunPrefab;
}
