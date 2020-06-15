using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudio 
{
    void PlayAudio();
    void PlayAudioWithClip(AudioClip clip);
    void PlayAudioWithClipAndSource(AudioClip clip,AudioSource source);
}
