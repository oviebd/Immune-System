using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour, IColliderEnter
{
    [SerializeField] private float _lifeTime = 2.0f;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private GameObject _graphicsObj;
    [SerializeField] private AudioClip _audioClip;


    private void Start()
    {
        Destroy(this.gameObject, _lifeTime);
    }

    public void onCollide(GameObject colidedObj)
    {
        HideAll();
    }

    void HideAll()
    {
       
        if (_collider2D != null)
            _collider2D.enabled = false;
        if (_graphicsObj != null)
            _graphicsObj.SetActive(false);
    }

    public AudioClip GetAudioClip()
    {
        return _audioClip;
    }

    
}
