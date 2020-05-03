using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour,IAudio
{
    private AudioSource _audioSource;
    [SerializeField] AudioClip _clip;


    private void Awake()
    {
        AudioManager.onAudioStateChange += AudioStateChanged;
    }
    private void OnDestroy()
    {
        AudioManager.onAudioStateChange -= AudioStateChanged;
    }


    public void PlayAudio()
    {
       if (AudioManager.instance.IsGameAudioOn() == false)
            return;
       if(GetAudioSource() != null && _clip != null)
        {
            _audioSource.clip = _clip;
            _audioSource.Play();
        }
    }
    public void PlayAudioWithClip(AudioClip clip)
    {
        if (AudioManager.instance.IsGameAudioOn() == false)
            return;
        if (GetAudioSource() != null && clip != null)
        {
            this._clip = clip;

            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }

    public void PlayAudioWithClipAndSource(AudioClip clip, AudioSource source)
    {
        if (AudioManager.instance.IsGameAudioOn() == false)
            return;
        if (source != null && clip != null)
        {
            this._clip = clip;
            this._audioSource = source;

            source.clip = clip;
            source.Play();
        }
    }

    private AudioSource GetAudioSource()
    {
        if (_audioSource == null)
            _audioSource = this.gameObject.GetComponent<AudioSource>();
        return _audioSource;
    }

    private void AudioStateChanged()
    {
        bool canPlaySound = AudioManager.instance.IsGameAudioOn();
        if (canPlaySound)
        {
            if (_audioSource != null && _clip != null)
                PlayAudioWithClipAndSource(this._clip, this._audioSource);
        }
        else
        {
            if (_audioSource != null && _clip != null && _audioSource.isPlaying)
                _audioSource.Stop();
        }
    }
}
