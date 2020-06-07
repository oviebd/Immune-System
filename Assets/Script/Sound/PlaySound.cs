using UnityEngine;

// It Control Audio Play 
[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour,IAudio
{
    private AudioSource _audioSource;
    [Header("Set Audio Clip Here (Optional), Or You can set audio clip through publc Api of this Script.")]
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
            PlayAudioWithClipAndSource(_clip, GetAudioSource());
        }
    }

    public void PlayAudioWithClip(AudioClip clip)
    {
        if (AudioManager.instance.IsGameAudioOn() == false)
            return;
        if (GetAudioSource() != null && clip != null)
        {
            PlayAudioWithClipAndSource(clip, GetAudioSource());
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
