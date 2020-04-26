using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public static BackGroundController instance;
    [SerializeField] private PlaySound _playSound;
    [SerializeField] private List<AudioClip> _audioClipList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetBackground( int levelNum)
    {
        levelNum = levelNum - 1;
        if (levelNum < 0)
            levelNum = 0;
        if(_playSound != null && _audioClipList != null && _audioClipList.Count > 0)
        {
            int index = 0;
            if ((levelNum % 2) != 0 && _audioClipList.Count > 1)
                index = 1;
            _playSound.PlayAudioWithClip(_audioClipList[index]);

        }
    }
}
