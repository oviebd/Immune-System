using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUiPanel : PanelBase
{
    [SerializeField] private Image _soundButton;
    [SerializeField] private Sprite _spriteSoundOn;
    [SerializeField] private Sprite _spriteSoundOff;

    private void Start()
    {
        AudioManager.onAudioStateChange += AudioStateChanged;
        SetSoundButtonGraphics();
    }
    private void OnDestroy()
    {
        AudioManager.onAudioStateChange -= AudioStateChanged;
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

}
