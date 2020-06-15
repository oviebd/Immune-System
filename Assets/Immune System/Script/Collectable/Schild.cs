using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schild : MonoBehaviour,IColliderEnter
{
    private GameObject _playerObj = null;
    [SerializeField] private Health _health;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private GameObject _graphicsObj;
    [SerializeField] private SpriteRenderer _spriteRenderer;


    private void Update()
    {
        if (GetPlayer() != null)
            transform.position = GetPlayer().transform.position;
    }

    private GameObject GetPlayer()
    {
        if (_playerObj == null && FindObjectOfType<PlayerController>() != null)
            _playerObj = FindObjectOfType<PlayerController>().gameObject;
        return _playerObj;
    }

    public void onCollide(GameObject colidedObj)
    {
        if (colidedObj.GetComponent<DamageAble>())
        {
            DamageAble damage = colidedObj.GetComponent<DamageAble>();
            if (_health != null){
                _health.ReduceHealth(damage.GetDamage());
                ChangeAlpha();
                if (_health.IsDie())
                {
                    DestroySchild();
                }
            }
        }
    }

    void ChangeAlpha()
    {
        if(_health != null && _spriteRenderer != null)
        {
            float alpha = _health.GetCurrentHealthAmount() * 1.0f / _health.GetMaxHealthAmount() * 1.0f;
            Color col = _spriteRenderer.color;
            col.a = alpha;
            Color newCol = col;
            _spriteRenderer.color = newCol;
        }
    }

    void DestroySchild()
    {
        _collider.enabled = false;
        _graphicsObj.SetActive(false);

    }


}
