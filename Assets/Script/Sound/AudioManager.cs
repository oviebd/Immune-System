using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public delegate void GameAudioStateChange();
    public static event GameAudioStateChange onAudioStateChange;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public bool IsGameAudioOn()
    {
        return GameDataHandler.instance.GetGameData().isSoundOn;
    }
    public void ChangeGameAudioStatus()
    {
        GameDataModel data = GameDataHandler.instance.GetGameData();
        Debug.Log(data.isSoundOn);
        data.isSoundOn = !data.isSoundOn;
        GameDataHandler.instance.SetGameData(data);

        if (onAudioStateChange != null)
            onAudioStateChange();

    }
}
