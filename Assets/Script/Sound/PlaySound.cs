using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour,IAudio
{
    private AudioSource _audioSource;
    [SerializeField] AudioClip _clip;

    public void PlayAudio()
    {
       if(GetAudioSource() != null && _clip != null)
        {
            _audioSource.clip = _clip;
            _audioSource.Play();
        }
    }
    public void PlayAudioWithClip(AudioClip clip)
    {
        if (GetAudioSource() != null && clip != null)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }

    public void PlayAudioWithClipAndSource(AudioClip clip, AudioSource source)
    {
        if (source != null && clip != null)
        {
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
}
