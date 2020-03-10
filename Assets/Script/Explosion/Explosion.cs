using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Explosion : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private AudioClip _explosionClip;


    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
        if (_audioSource != null && _explosionClip != null)
        {
            _audioSource.clip = _explosionClip;
        }
    }

    public void Explode()
    {
        InstantiateEffect();

        if (_audioSource != null && _explosionClip != null)
        {
            _audioSource.Play();
        }
    }

    void InstantiateEffect()
    {
        if (_explosionEffect != null)
        {
            GameObject effectParticle = InstantiatorHelper.InstantiateObject(_explosionEffect, this.gameObject);
            Destroy(effectParticle, 1.0f);
        }
    }


}
