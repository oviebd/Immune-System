using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour,IColliderEnter
{
    [SerializeField] private GameEnum.CollectableType _type;
    [SerializeField] private GameObject _graphicsObj;
    [SerializeField] private Collider2D _collider;

    protected ICollectable _iCollectable;
    private Explosion _explosion;

    
    protected void SetCollectable(ICollectable collectable)
    {
        this._iCollectable = collectable;
    }

    public void onCollide(GameObject colidedObj)
    {
        DestroyObj();
        if(_iCollectable != null)
            _iCollectable.ExecuteCollectableEffect();

        if (this.gameObject.GetComponent<Explosion>() != null)
            this.gameObject.GetComponent<Explosion>().Explode();
        
    }

    protected void DestroyObj()
    {
        _collider.enabled = false;
        _graphicsObj.SetActive(false);

        Destroy(this.gameObject, 2.0f);
    }

    public GameEnum.CollectableType GetCollectableType()
    {
        return _type;
    }

    protected PlayerController GetPlayerControler()
    {
        if (FindObjectOfType<PlayerController>() != null)
            return FindObjectOfType<PlayerController>();

        return null;
    }
}
